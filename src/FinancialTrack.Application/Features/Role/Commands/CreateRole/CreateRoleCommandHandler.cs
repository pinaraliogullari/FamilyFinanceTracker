using MediatR;

namespace FinancialTrack.Application.Features.Role.Commands.CreateRole;

public class CreateRoleCommandHandler:IRequestHandler<CreateRoleCommandRequest,CreateRoleCommandResponse>
{
    public Task<CreateRoleCommandResponse> Handle(CreateRoleCommandRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}