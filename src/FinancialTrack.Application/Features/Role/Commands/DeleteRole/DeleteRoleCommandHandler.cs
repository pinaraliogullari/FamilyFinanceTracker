using MediatR;

namespace FinancialTrack.Application.Features.Role.Commands.DeleteRole;

public class DeleteRoleCommandHandler: IRequestHandler<DeleteRoleCommandRequest, DeleteRoleCommandResponse>
{
    public Task<DeleteRoleCommandResponse> Handle(DeleteRoleCommandRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}