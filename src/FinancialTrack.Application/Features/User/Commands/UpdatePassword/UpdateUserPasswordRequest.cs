using FinancialTrack.Application.Wrappers;
using MediatR;

namespace FinancialTrack.Application.Features.User.Commands.UpdatePassword;

public class UpdateUserPasswordRequest:IRequest<ApiResult<UpdateUserPasswordResponse>>
{
    public long UserId  { get; set; }
    public string OldPassword { get; set; }
    public string NewPassword  { get; set; }
    public string NewPasswordConfirm { get; set; }
}