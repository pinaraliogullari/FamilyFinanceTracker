using FinancialTrack.Core.Markers;

namespace FinancialTrack.Application.Features.Role.Commands.CreateRole;

public class CreateRoleCommandRequest : IBaseCommandRequest<CreateRoleCommandResponse>
{
    public string Name { get; set; }
}