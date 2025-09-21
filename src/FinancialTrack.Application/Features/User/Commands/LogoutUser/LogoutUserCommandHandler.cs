using System.Net;
using FinancialTrack.Application.Services;
using FinancialTrack.Application.Wrappers;
using MediatR;

namespace FinancialTrack.Application.Features.User.Commands.LogoutUser;

public class LogoutUserCommandHandler : IRequestHandler<LogoutUserCommandRequest, ApiResult<object>>
{
    private readonly IAuthService _authService;

    public LogoutUserCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<ApiResult<object>> Handle(LogoutUserCommandRequest request,
        CancellationToken cancellationToken)
    {
        var response = await _authService.LogoutAsync();
        if (!response.Success)
            return ApiResult<object>.FailureResult(message: response.Message, statusCode: HttpStatusCode.Unauthorized);
        
        return ApiResult<object>.SuccessResult(message: response.Message);
    }
}