using FinancialTrack.Application.Exceptions;
using FinancialTrack.Core.UoW;
using FinancialTrack.Persistence.Context;
using MediatR;

namespace FinancialTrack.Application.Features.User.Commands.UpdateUserProfile;

public class
    UpdateUserProfileCommandHandler : IRequestHandler<UpdateUserProfileCommandRequest, UpdateUserProfileCommandResponse>
{
    private readonly IGenericUnitofWork<FinancialTrackDbContext> _uow;

    public UpdateUserProfileCommandHandler(IGenericUnitofWork<FinancialTrackDbContext> uow)
    {
        _uow = uow;
    }

    public async Task<UpdateUserProfileCommandResponse> Handle(UpdateUserProfileCommandRequest request,
        CancellationToken cancellationToken)
    {
        var user = await _uow.GetReadRepository<Domain.Entities.User>().GetByIdAsync(request.UserId);
        if (user == null)
            throw new NotFoundException($"$User with id {request.UserId} not found");
        user.FirstName = request.FirstName;
        user.LastName = request.LastName;
        user.Email = request.Email;
        _uow.GetWriteRepository<Domain.Entities.User>().Update(user);
        return new UpdateUserProfileCommandResponse()
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
        };
    }
}