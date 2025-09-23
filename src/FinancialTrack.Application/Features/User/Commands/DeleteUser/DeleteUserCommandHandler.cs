using FinancialTrack.Application.Services;
using MediatR;

namespace FinancialTrack.Application.Features.User.Commands.DeleteUser;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommandRequest, DeleteUserCommandResponse>
{
    private readonly IUserService _userService;

    public DeleteUserCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<DeleteUserCommandResponse> Handle(DeleteUserCommandRequest request,
        CancellationToken cancellationToken)
    {
        await _userService.DeleteUserAsync(request.UserId);
        return new DeleteUserCommandResponse()
        {
            Success = true,
            UserId = request.UserId
        };
    }
}