using FinancialTrack.Application.Wrappers;
using MediatR;

namespace FinancialTrack.Application.Features.User.Commands.DeleteUser;

public class DeleteUserCommandRequest:IRequest<ApiResult<DeleteUserCommandResponse>>
{
    public long UserId { get; set; }
}