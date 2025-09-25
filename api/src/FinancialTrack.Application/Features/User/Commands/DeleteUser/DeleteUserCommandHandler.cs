using FinancialTrack.Application.Exceptions;
using FinancialTrack.Core.UoW;
using FinancialTrack.Persistence.AbstractRepositories.UserRepository;
using FinancialTrack.Persistence.Context;
using MediatR;

namespace FinancialTrack.Application.Features.User.Commands.DeleteUser;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommandRequest, DeleteUserCommandResponse>
{
    private readonly IUserWriteRepository _userWriteRepository;
    private readonly IUserReadRepository _userReadRepository;
    private readonly IGenericUnitofWork<FinancialTrackDbContext> _uow;

    public DeleteUserCommandHandler
    (
        IUserReadRepository userReadRepository,
        IUserWriteRepository userWriteRepository,
        IGenericUnitofWork<FinancialTrackDbContext> uow
    )
    {
        _userReadRepository = userReadRepository;
        _userWriteRepository = userWriteRepository;
        _uow = uow;
    }

    public async Task<DeleteUserCommandResponse> Handle(DeleteUserCommandRequest request,
        CancellationToken cancellationToken)
    {
        var user = await _userReadRepository.GetByIdAsync(request.UserId);
        if (user == null)
            throw new NotFoundException($"User with id {request.UserId} not found");
        _userWriteRepository.Remove(user);
        //await _uow.SaveChangesAsync();
        return new DeleteUserCommandResponse()
        {
            UserId = user.Id,
        };
    }
}