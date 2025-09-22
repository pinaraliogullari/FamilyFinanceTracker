using FinancialTrack.Application.DTOs;
using FinancialTrack.Application.Exceptions;
using FinancialTrack.Application.Helpers;
using FinancialTrack.Application.Repositories.RoleRepository;
using FinancialTrack.Application.Repositories.UserRepository;
using FinancialTrack.Application.Services;
using FinancialTrack.Application.UoW;
using FinancialTrack.Domain.Entities;
using FinancialTrack.Persistence.Context;

namespace FinancialTrack.Persistence.Services;

public class UserService : IUserService
{
    private readonly IUserWriteRepository _userWriteRepository;
    private readonly IUserReadRepository _userReadRepository;
    private readonly IRoleReadRepository _roleReadRepository;
    private readonly IGenericUnitofWork<FinancialTrackDbContext> _uow;

    public UserService
    (
        IUserReadRepository userReadRepository,
        IUserWriteRepository userWriteRepository,
        IRoleReadRepository roleReadRepository,
        IGenericUnitofWork<FinancialTrackDbContext> uow
    )
    {
        _userReadRepository = userReadRepository;
        _userWriteRepository = userWriteRepository;
        _roleReadRepository = roleReadRepository;
        _uow = uow;
    }

    public async Task<CreateUserResponse> CreateUserAsync(CreateUser dto)
    {
        if (dto.Password != dto.ConfirmPassword)
            throw new InvalidOperationException("Password and ConfirmPassword does not match");

        var user = _userReadRepository.GetWhere(u => u.Email == dto.Email).FirstOrDefault();
        if (user != null)
            throw new InvalidOperationException($"User with email {dto.Email} has already been created");

        var hashPassword = PasswordHasher.CreateHashPassword(dto.Password);
        var newUser = new User()
        {
            FirstName = dto.Firstname,
            LastName = dto.Lastname,
            Email = dto.Email,
            Password = hashPassword,
            RoleId = 1,
        };
        await _userWriteRepository.AddAsync(newUser);
        await _uow.SaveChangesAsync();

        return new CreateUserResponse()
        {
            Id = newUser.Id,
            Firstname = newUser.FirstName,
            Lastname = newUser.LastName,
            Email = newUser.Email,
        };
    }

    public async Task UpdateUserRoleAsync(UpdateUserRole dto )
    {
        var user = await _userReadRepository.GetByIdAsync(dto.UserId);
        if (user == null)
            throw new NotFoundException($"User with id {dto.UserId} not found");

        var role = await _roleReadRepository.GetByIdAsync(dto.RoleId);
        if (role == null)
            throw new NotFoundException($"Role with id {dto.RoleId} not found");

        user.RoleId = dto.RoleId;
        _userWriteRepository.Update(user);
        await _uow.SaveChangesAsync();
    }

    public async Task UpdateUserPasswordAsync(UpdateUserPassword dto)
    {
        var user = await _userReadRepository.GetByIdAsync(dto.UserId);
        if (user == null)
            throw new NotFoundException($"User with id {dto.UserId} not found");

        if (dto.NewPassword != dto.NewPasswordConfirm)
            throw new InvalidOperationException("New password and confirm password do not match.");

        if (!PasswordHasher.Verify(dto.OldPassword, user.Password))
            throw new UnauthorizedAccessException("Old password is incorrect.");

        user.Password = PasswordHasher.CreateHashPassword(dto.NewPassword);
        _userWriteRepository.Update(user);
        await _uow.SaveChangesAsync();
    }
}