using MediatR;

namespace FinancialTrack.Application.Features.Role.Commands.UpdateRole;

public class UpdateRoleCommandRequest : IRequest<UpdateRoleCommandResponse>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}