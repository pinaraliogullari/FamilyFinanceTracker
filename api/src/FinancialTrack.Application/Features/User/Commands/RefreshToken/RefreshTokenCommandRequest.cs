using FinancialTrack.Core.Markers;

namespace FinancialTrack.Application.Features.User.Commands.RefreshToken;

public class RefreshTokenCommandRequest:IBaseCommandRequest<RefreshTokenCommandResponse>
{
    public string RefreshToken { get; set; }
    public string ExpiredAccessToken { get; set; }
}