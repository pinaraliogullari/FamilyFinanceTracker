using MediatR;

namespace FinancialTrack.Application.Features.Role.Commands.CreateRole;

public class CreateRoleCommandRequest : IRequest<CreateRoleCommandResponse>
{
    public string Name { get; set; }
}