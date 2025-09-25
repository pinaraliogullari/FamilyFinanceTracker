using FinancialTrack.Core.Markers;

namespace FinancialTrack.Application.Features.User.Commands.DeleteUser;

public class DeleteUserCommandRequest:IBaseCommandRequest<DeleteUserCommandResponse>
{
    public long UserId { get; set; }
}