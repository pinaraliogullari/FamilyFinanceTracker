using FinancialTrack.Core.AbstractServices;
using MediatR;
using Microsoft.Extensions.Logging;

namespace FinancialTrack.Application.Features.User.Commands.LogoutUser;

public class LogoutUserCommandHandler : IRequestHandler<LogoutUserCommandRequest, LogoutUserCommandResponse>
{
    
    private readonly ITokenService _tokenService;
    private readonly ICurrentUserService _currentUserService;
    private readonly ILogger<LogoutUserCommandHandler> _logger;

    public LogoutUserCommandHandler
    (
        ITokenService tokenService,
        ICurrentUserService currentUserService,
        ILogger<LogoutUserCommandHandler> logger
    )
    {
        _tokenService = tokenService;
        _currentUserService = currentUserService;
        _logger = logger;
    }

    public async Task<LogoutUserCommandResponse> Handle(LogoutUserCommandRequest request,
        CancellationToken cancellationToken)
    {
        var accessToken = _currentUserService.Token;
        var userId = _currentUserService.UserId;
        var claims = _tokenService.GetClaims(accessToken);

        if (claims == null || !claims.Any())
        {
            /*Claims null ise kullanıcı authorize şekilde bu komuta gelmiş fakat sistem tarafından üretilmeyen bir access tokena sahip demektir.*/
            var ipAddress = _currentUserService.IPAddress;
            _logger.LogWarning($"UnAuthorize request with access token: {accessToken} on ip: {ipAddress}");
            return new ()
            {
                Message = "UnAuthorize request with access token",
                Success = false
            };
        }

        await _tokenService.RemoveOldTokens(userId);
        return new LogoutUserCommandResponse()
        {
            Message = "User logged out successfully",
            Success = true
        };
    }
}