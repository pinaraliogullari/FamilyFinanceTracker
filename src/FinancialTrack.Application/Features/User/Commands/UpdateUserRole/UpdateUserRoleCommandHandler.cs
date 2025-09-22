using FinancialTrack.Application.DTOs;
using FinancialTrack.Application.Features.User.Commands.UpdateUserRole;
using FinancialTrack.Application.Services;
using FinancialTrack.Application.Wrappers;
using MediatR;

namespace FinancialTrack.Application.Features.User.Commands.UpdateUser;

public class
    UpdateUserRoleCommandHandler : IRequestHandler<UpdateUserRoleCommandRequest,
    ApiResult<UpdateUserRoleCommandResponse>>
{
    private readonly IUserService _userService;

    public UpdateUserRoleCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<ApiResult<UpdateUserRoleCommandResponse>> Handle(UpdateUserRoleCommandRequest request,
        CancellationToken cancellationToken)
    {
        var updateUserRole = new DTOs.UpdateUserRoleDto()
        {
            UserId = request.UserId,
            RoleId = request.RoleId
        };
        await _userService.UpdateUserRoleAsync(updateUserRole);
        
        return ApiResult<UpdateUserRoleCommandResponse>.SuccessResult(new UpdateUserRoleCommandResponse()
            { UserId = request.UserId, RoleId = request.RoleId }, "User's role has been updated.");
    }
}