using FinancialTrack.Application.Exceptions;
using FinancialTrack.Core.UoW;
using FinancialTrack.Persistence.Context;
using MediatR;

namespace FinancialTrack.Application.Features.User.Commands.DeleteUser;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommandRequest, DeleteUserCommandResponse>
{
    private readonly IGenericUnitofWork<FinancialTrackDbContext> _uow;

    public DeleteUserCommandHandler(IGenericUnitofWork<FinancialTrackDbContext> uow)
    {
        _uow = uow;
    }

    public async Task<DeleteUserCommandResponse> Handle(DeleteUserCommandRequest request,
        CancellationToken cancellationToken)
    {
        var user = await _uow.GetReadRepository<Domain.Entities.User>().GetByIdAsync(request.UserId);
        if (user == null)
            throw new NotFoundException($"User with id {request.UserId} not found");
        _uow.GetWriteRepository<Domain.Entities.User>().Remove(user);

        return new DeleteUserCommandResponse()
        {
            UserId = user.Id,
        };
    }
}