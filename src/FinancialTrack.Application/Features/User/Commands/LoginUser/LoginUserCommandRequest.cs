using FinancialTrack.Application.Wrappers;
using MediatR;

namespace FinancialTrack.Application.Features.User.Commands.LoginUser;

public class LoginUserCommandRequest: IRequest<ApiResult<LoginUserCommandResponse>>
{
    public string  Email { get; set; }
    public string  Password { get; set; }  
}