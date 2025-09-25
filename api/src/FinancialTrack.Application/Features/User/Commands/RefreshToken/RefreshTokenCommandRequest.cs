using FinancialTrack.Application.Wrappers;
using MediatR;

namespace FinancialTrack.Application.Features.User.Commands.RefreshToken;

public class RefreshTokenCommandRequest:IRequest<RefreshTokenCommandResponse>
{
    public string RefreshToken { get; set; }
    public string ExpiredAccessToken { get; set; }
}