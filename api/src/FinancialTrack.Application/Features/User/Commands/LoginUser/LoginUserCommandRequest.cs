using FinancialTrack.Core.Markers;

namespace FinancialTrack.Application.Features.User.Commands.LoginUser;

public class LoginUserCommandRequest: IBaseCommandRequest<LoginUserCommandResponse>
{
    public string  Email { get; set; }
    public string  Password { get; set; }  
}