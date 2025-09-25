using FinancialTrack.Core.Markers;

namespace FinancialTrack.Application.Features.User.Commands.UpdateUserPassword;

public class UpdateUserPasswordCommandRequest : IBaseCommandRequest<UpdateUserPasswordCommandResponse>
{
    public long UserId { get; set; }
    public string OldPassword { get; set; }
    public string NewPassword { get; set; }
    public string NewPasswordConfirm { get; set; }
}