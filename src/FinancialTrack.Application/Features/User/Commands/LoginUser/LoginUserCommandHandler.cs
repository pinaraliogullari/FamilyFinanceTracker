using System.Net;
using FinancialTrack.Application.Services;
using FinancialTrack.Application.Wrappers;
using MediatR;

namespace FinancialTrack.Application.Features.User.Commands.LoginUser;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, ApiResult<LoginUserCommandResponse>>
{
    private readonly IAuthService _authService;

    public LoginUserCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<ApiResult<LoginUserCommandResponse>> Handle(LoginUserCommandRequest request,
        CancellationToken cancellationToken)
    {
        var loginUser = new DTOs.LoginUser()
        {
            Email = request.Email,
            Password = request.Password
        };
        var response = await _authService.LoginAsync(loginUser);
        if (response.Token == null)
        {
            return ApiResult<LoginUserCommandResponse>.FailureResult(statusCode: HttpStatusCode.Unauthorized);
        }

        var loginUserCommandResponse = new LoginUserCommandResponse
        {
            Token = response.Token
        };

        return ApiResult<LoginUserCommandResponse>.SuccessResult(loginUserCommandResponse);
    }
}