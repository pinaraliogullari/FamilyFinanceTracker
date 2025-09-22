using FinancialTrack.Application.DTOs;
using FinancialTrack.Application.Services;
using FinancialTrack.Application.Wrappers;
using MediatR;

namespace FinancialTrack.Application.Features.User.Commands.UpdatePassword;

public class UpdateUserPasswordHandler:IRequestHandler<UpdateUserPasswordRequest, ApiResult<UpdateUserPasswordResponse>>
{
    private readonly IUserService  _userService;

    public UpdateUserPasswordHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<ApiResult<UpdateUserPasswordResponse>> Handle(UpdateUserPasswordRequest request, CancellationToken cancellationToken)
    {
        var updateUserPasswordDto = new UpdateUserPassword()
        {
            NewPassword = request.NewPassword,
            OldPassword = request.OldPassword,
            NewPasswordConfirm = request.NewPasswordConfirm,
        };
        await _userService.UpdateUserPasswordAsync(updateUserPasswordDto);
        return ApiResult<UpdateUserPasswordResponse>.SuccessResult(message:"User's password has been updated.");
    }
}