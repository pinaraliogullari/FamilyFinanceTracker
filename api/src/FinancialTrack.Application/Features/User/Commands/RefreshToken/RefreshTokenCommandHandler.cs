using FinancialTrack.Application.Constants;
using FinancialTrack.Core.AbstractServices;
using MediatR;

namespace FinancialTrack.Application.Features.User.Commands.RefreshToken;

public class
    RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommandRequest, RefreshTokenCommandResponse>
{
   private readonly ITokenService _tokenService;

   public RefreshTokenCommandHandler(ITokenService tokenService)
   {
       _tokenService = tokenService;
   }

   public async Task<RefreshTokenCommandResponse> Handle(RefreshTokenCommandRequest request,
        CancellationToken cancellationToken)
    {
        var claims = _tokenService.GetClaims(request.ExpiredAccessToken);
        if (claims == null || !claims.Any())
            throw new UnauthorizedAccessException("Invalid claims");

        var userId = claims.FirstOrDefault(x => x.Type == ClaimKey.UserId)?.Value;
        if (userId == null)
            throw new UnauthorizedAccessException("User not found");
        if (!_tokenService.IsValidRefrehToken(userId, request.RefreshToken))
            throw new UnauthorizedAccessException("Invalid or expired refresh token");

        await _tokenService.RemoveOldTokens(userId);
        var newToken = await _tokenService.CreateAccessTokenAsync(claims.ToArray());
        return new RefreshTokenCommandResponse()
        {
            Token = newToken,
        };
    }
}