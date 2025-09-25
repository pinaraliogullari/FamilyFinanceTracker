using FinancialTrack.Application.Wrappers;
using MediatR;

namespace FinancialTrack.Application.Features.User.Commands.UpdateUserPassword;

public class UpdateUserPasswordCommandRequest : IRequest<UpdateUserPasswordCommandResponse>
{
    public long UserId { get; set; }
    public string OldPassword { get; set; }
    public string NewPassword { get; set; }
    public string NewPasswordConfirm { get; set; }
}