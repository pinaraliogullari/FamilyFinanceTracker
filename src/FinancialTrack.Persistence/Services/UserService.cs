using FinancialTrack.Application.DTOs;
using FinancialTrack.Application.Helpers;
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
    private readonly IGenericUnitofWork<FinancialTrackDbContext> _uow;

    public UserService
    (
        IUserWriteRepository userWriteRepository,
        IGenericUnitofWork<FinancialTrackDbContext> uow
    )
    {
        _userWriteRepository = userWriteRepository;
        _uow = uow;
    }

    public async Task<CreateUserResponse> CreateUserAsync(CreateUser model)
    {
        if (model.Password != model.ConfirmPassword)
            throw new InvalidOperationException("Password and ConfirmPassword does not match");
        
        var user=_userReadRepository.GetWhere(u => u.Email == model.Email);
        if (user != null)
            throw new InvalidOperationException($"User with email {model.Email} has already been created");
            
        var hashPassword = PasswordHasher.CreateHashPassword(model.Password);
        var newUser = new User()
        {
            FirstName = model.Firstname,
            LastName = model.Lastname,
            Email = model.Email,
            Password = hashPassword,
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
}