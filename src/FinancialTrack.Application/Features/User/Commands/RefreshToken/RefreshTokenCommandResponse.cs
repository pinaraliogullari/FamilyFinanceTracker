using FinancialTrack.Application.DTOs;

namespace FinancialTrack.Application.Features.User.Commands.RefreshToken;

public class RefreshTokenCommandResponse
{
    public Token Token { get; set; }
}