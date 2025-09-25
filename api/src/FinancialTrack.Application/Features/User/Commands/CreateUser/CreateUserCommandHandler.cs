using FinancialTrack.Application.Helpers;
using FinancialTrack.Core.UoW;
using FinancialTrack.Persistence.Context;
using MediatR;

namespace FinancialTrack.Application.Features.User.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
{
    private readonly IGenericUnitofWork<FinancialTrackDbContext> _uow;

    public CreateUserCommandHandler(IGenericUnitofWork<FinancialTrackDbContext> uow)
    {
        _uow = uow;
    }

    public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request,
        CancellationToken cancellationToken)
    {
        if (request.Password != request.ConfirmPassword)
            throw new InvalidOperationException("Password and ConfirmPassword does not match");

        var user = _uow.GetReadRepository<Domain.Entities.User>().GetWhere(u => u.Email == request.Email)
            .FirstOrDefault();
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
        await _uow.GetWriteRepository<Domain.Entities.User>().AddAsync(newUser);

        return new CreateUserCommandResponse()
        {
            Id = newUser.Id,
            Firstname = newUser.FirstName,
            Lastname = newUser.LastName,
            Email = newUser.Email,
        };
    }
}