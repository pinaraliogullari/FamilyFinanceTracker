using FinancialTrack.Application.Features.User.Commands.UpdateUser;
using FinancialTrack.Application.Wrappers;
using MediatR;

namespace FinancialTrack.Application.Features.User.Commands.UpdateUserRole;

public class UpdateUserRoleCommandRequest : IRequest<UpdateUserRoleCommandResponse>
{
    public long UserId { get; set; }
    public long RoleId { get; set; }
}