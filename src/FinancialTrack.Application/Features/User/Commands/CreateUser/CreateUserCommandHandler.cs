using FinancialTrack.Application.Services;
using MediatR;

namespace FinancialTrack.Application.Features.User.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
{
    private readonly IUserService _userService;

    public CreateUserCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request,
        CancellationToken cancellationToken)
    {
        var createUserModel = new DTOs.CreateUser()
        {
            Firstname = request.Firstname,
            Lastname = request.Lastname,
            Email = request.Email,
            Password = request.Password,
            ConfirmPassword = request.ConfirmPassword,
        };
        var result = await _userService.CreateUserAsync(createUserModel);
        throw new NotImplementedException();
    }
}