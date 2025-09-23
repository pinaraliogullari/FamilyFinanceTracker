using FinancialTrack.Application.Services;
using FinancialTrack.Application.Wrappers;
using MediatR;

namespace FinancialTrack.Application.Features.User.Commands.DeleteUser;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommandRequest, ApiResult<DeleteUserCommandResponse>>
{
    private readonly IUserService _userService;

    public DeleteUserCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<ApiResult<DeleteUserCommandResponse>> Handle(DeleteUserCommandRequest request,
        CancellationToken cancellationToken)
    {
        await _userService.DeleteUserAsync(request.UserId);
        var deleteUserCommandResponse = new DeleteUserCommandResponse()
        {
         
            UserId = request.UserId
        };
        return ApiResult<DeleteUserCommandResponse>.SuccessResult(deleteUserCommandResponse);
    }
}