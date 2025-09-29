using FinancialTrack.Application.Exceptions;
using FinancialTrack.Core.UoW;
using FinancialTrack.Persistence.Context;
using MediatR;

namespace FinancialTrack.Application.Features.User.Commands.UpdateUserRole;

public class
    UpdateUserRoleCommandHandler : IRequestHandler<UpdateUserRoleCommandRequest,
    UpdateUserRoleCommandResponse>
{
    private readonly IGenericUnitofWork<FinancialTrackDbContext> _uow;


    public UpdateUserRoleCommandHandler(IGenericUnitofWork<FinancialTrackDbContext> uow)
    {
        _uow = uow;
    }

    public async Task<UpdateUserRoleCommandResponse> Handle(UpdateUserRoleCommandRequest request,
        CancellationToken cancellationToken)
    {
        var user = await _uow.GetReadRepository<Domain.Entities.User>().GetByIdAsync(request.UserId);
        if (user == null)
            throw new NotFoundException($"User with id {request.UserId} not found");

        var role = await _uow.GetReadRepository<Domain.Entities.Role>().GetByIdAsync(request.RoleId);
        if (role == null)
            throw new NotFoundException($"Role with id {request.RoleId} not found");

        user.RoleId = request.RoleId;
        _uow.GetWriteRepository<Domain.Entities.User>().Update(user);

        return new UpdateUserRoleCommandResponse()
        {
            RoleId = role.Id,
            UserId = user.Id,
        };
    }
}