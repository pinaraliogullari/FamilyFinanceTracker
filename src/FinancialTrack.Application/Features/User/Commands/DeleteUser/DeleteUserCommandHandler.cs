using MediatR;

namespace FinancialTrack.Application.Features.User.Commands.DeleteUser;

public class DeleteUserCommandHandler: IRequestHandler<DeleteUserCommandRequest, DeleteUserCommandResponse>
{
    public Task<DeleteUserCommandResponse> Handle(DeleteUserCommandRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}