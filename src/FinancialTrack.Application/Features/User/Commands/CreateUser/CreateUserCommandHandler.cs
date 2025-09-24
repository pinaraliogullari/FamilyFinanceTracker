using FinancialTrack.Application.Helpers;
using FinancialTrack.Infrastructure.UoW;
using FinancialTrack.Persistence.AbstractRepositories.RoleRepository;
using FinancialTrack.Persistence.AbstractRepositories.UserRepository;
using FinancialTrack.Persistence.Context;
using MediatR;

namespace FinancialTrack.Application.Features.User.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
{
    private readonly IUserWriteRepository _userWriteRepository;
    private readonly IUserReadRepository _userReadRepository;
    private readonly IGenericUnitofWork<FinancialTrackDbContext> _uow;

    public CreateUserCommandHandler
    (
        IUserReadRepository userReadRepository,
        IUserWriteRepository userWriteRepository,
        IRoleReadRepository roleReadRepository,
        IGenericUnitofWork<FinancialTrackDbContext> uow
    )
    {
        _userReadRepository = userReadRepository;
        _userWriteRepository = userWriteRepository;
        _uow = uow;
    }

    public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request,
        CancellationToken cancellationToken)
    {
        if (request.Password != request.ConfirmPassword)
            throw new InvalidOperationException("Password and ConfirmPassword does not match");

        var user = _userReadRepository.GetWhere(u => u.Email == request.Email).FirstOrDefault();
        if (user != null)
            throw new InvalidOperationException($"User with email {request.Email} has already been created");

        var hashPassword = PasswordHasher.CreateHashPassword(request.Password);
        var newUser = new Domain.Entities.User()
        {
            FirstName = request.Firstname,
            LastName = request.Lastname,
            Email = request.Email,
            Password = hashPassword,
            RoleId = 1,
        };
        await _userWriteRepository.AddAsync(newUser);
        await _uow.SaveChangesAsync();

        return new CreateUserCommandResponse()
        {
            Id = newUser.Id,
            Firstname = newUser.FirstName,
            Lastname = newUser.LastName,
            Email = newUser.Email,
        };
    }
}