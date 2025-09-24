using FinancialTrack.Application.Exceptions;
using FinancialTrack.Application.Features.User.Commands.UpdateUser;
using FinancialTrack.Infrastructure.UoW;
using FinancialTrack.Persistence.AbstractRepositories.RoleRepository;
using FinancialTrack.Persistence.AbstractRepositories.UserRepository;
using FinancialTrack.Persistence.Context;
using MediatR;

namespace FinancialTrack.Application.Features.User.Commands.UpdateUserRole;

public class
    UpdateUserRoleCommandHandler : IRequestHandler<UpdateUserRoleCommandRequest,
    UpdateUserRoleCommandResponse>
{
    private readonly IUserReadRepository _userReadRepository;
    private readonly IUserWriteRepository _userWriteRepository;
    private readonly IRoleReadRepository _roleReadRepository;
    private readonly IGenericUnitofWork<FinancialTrackDbContext> _uow;

    public UpdateUserRoleCommandHandler
    (
        IUserReadRepository userReadRepository,
        IUserWriteRepository userWriteRepository,
        IRoleReadRepository roleReadRepository,
        IGenericUnitofWork<FinancialTrackDbContext> uow
    )
    {
        _userReadRepository = userReadRepository;
        _userWriteRepository = userWriteRepository;
        _roleReadRepository = roleReadRepository;
        _uow = uow;
    }


    public async Task<UpdateUserRoleCommandResponse> Handle(UpdateUserRoleCommandRequest request,
        CancellationToken cancellationToken)
    {
        var user = await _userReadRepository.GetByIdAsync(request.UserId);
        if (user == null)
            throw new NotFoundException($"User with id {request.UserId} not found");

        var role = await _roleReadRepository.GetByIdAsync(request.RoleId);
        if (role == null)
            throw new NotFoundException($"Role with id {request.RoleId} not found");

        user.RoleId = request.RoleId;
        _userWriteRepository.Update(user);
        await _uow.SaveChangesAsync();

        return new UpdateUserRoleCommandResponse()
        {
            RoleId = role.Id,
            UserId = user.Id,
        };
    }
}