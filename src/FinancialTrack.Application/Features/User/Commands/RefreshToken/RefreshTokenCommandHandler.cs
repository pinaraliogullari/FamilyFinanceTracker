using System.Net;
using FinancialTrack.Application.Services;
using FinancialTrack.Application.Wrappers;
using MediatR;

namespace FinancialTrack.Application.Features.User.Commands.RefreshToken;

public class
    RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommandRequest, ApiResult<RefreshTokenCommandResponse>>
{
    private readonly IAuthService _authService;

    public RefreshTokenCommandHandler(IAuthService authService)
    {
        _authService = authService;
    }

    public async Task<ApiResult<RefreshTokenCommandResponse>> Handle(RefreshTokenCommandRequest request,
        CancellationToken cancellationToken)
    {
        var newTokenResult =
            await _authService.RefreshTokenLoginAsync(request.RefreshToken, request.ExpiredAccessToken);
        if (newTokenResult.Token == null)
        {
            return ApiResult<RefreshTokenCommandResponse>.FailureResult(statusCode: HttpStatusCode.Unauthorized);
        }

        return ApiResult<RefreshTokenCommandResponse>.SuccessResult(new RefreshTokenCommandResponse
            {
                Token = newTokenResult.Token,
            }
        );
    }
}