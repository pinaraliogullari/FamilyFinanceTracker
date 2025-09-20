using FinancialTrack.Application.Services;
using FinancialTrack.Application.Wrappers;
using MediatR;

namespace FinancialTrack.Application.Features.User.Commands.CreateUser;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, ApiResult<CreateUserCommandResponse>>
{
    private readonly IUserService _userService;

    public CreateUserCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<ApiResult<CreateUserCommandResponse>> Handle(CreateUserCommandRequest request,
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
        var response = await _userService.CreateUserAsync(createUserModel);
        var createUserCommandResponse = new CreateUserCommandResponse()
        {
            Id = response.Id,
            Email = response.Email,
            Firstname = response.Firstname,
            Lastname = response.Lastname,
        };
        return ApiResult<CreateUserCommandResponse>.SuccessResult(createUserCommandResponse);
    }
}