using FinancialTrack.Application.Features.User.Commands.UpdateUser;
using FinancialTrack.Core.Markers;

namespace FinancialTrack.Application.Features.User.Commands.UpdateUserRole;

public class UpdateUserRoleCommandRequest : IBaseCommandRequest<UpdateUserRoleCommandResponse>
{
    public long UserId { get; set; }
    public long RoleId { get; set; }
}