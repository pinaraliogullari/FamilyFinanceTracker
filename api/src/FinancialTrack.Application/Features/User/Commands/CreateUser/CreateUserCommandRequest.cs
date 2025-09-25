using FinancialTrack.Core.Markers;

namespace FinancialTrack.Application.Features.User.Commands.CreateUser;

public class CreateUserCommandRequest:IBaseCommandRequest<CreateUserCommandResponse>
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}