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

    public async Task<CreateUserResponse> CreateUserAsync(CreateUser model)
    {
        if (model.Password != model.ConfirmPassword)
            throw new InvalidOperationException("Password and ConfirmPassword does not match");

        var user = _userReadRepository.GetWhere(u => u.Email == model.Email).FirstOrDefault();
        if (user != null)
            throw new InvalidOperationException($"User with email {model.Email} has already been created");

        var hashPassword = PasswordHasher.CreateHashPassword(model.Password);
        var newUser = new User()
        {
            FirstName = model.Firstname,
            LastName = model.Lastname,
            Email = model.Email,
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

    public async Task UpdateUserRoleAsync(UpdateUserRole model)
    {
        var user = await _userReadRepository.GetByIdAsync(model.UserId);
        if (user == null)
            throw new NotFoundException($"User with id {model.UserId} not found");

        var role = await _roleReadRepository.GetByIdAsync(model.RoleId);
        if (role == null)
            throw new NotFoundException($"Role with id {model.RoleId} not found");

        user.RoleId = model.RoleId;
        _userWriteRepository.Update(user);
        await _uow.SaveChangesAsync();
    }
}