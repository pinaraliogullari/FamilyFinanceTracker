using FinancialTrack.Application.Exceptions;
using FinancialTrack.Core.AbstractServices;
using FinancialTrack.Core.UoW;
using FinancialTrack.Persistence.Context;
using MediatR;

namespace FinancialTrack.Application.Features.User.Queries.GetMyProfile;

public class GetMyProfileQueryRequestHandler : IRequestHandler<GetMyProfileQueryRequest, GetMyProfileQueryResponse>
{
    private readonly IGenericUnitofWork<FinancialTrackDbContext> _uow;
    private readonly ICurrentUserService _currentUserService;

    public GetMyProfileQueryRequestHandler
    (
        IGenericUnitofWork<FinancialTrackDbContext> uow,
        ICurrentUserService currentUserService
    )
    {
        _uow = uow;
        _currentUserService = currentUserService;
    }


    public async Task<GetMyProfileQueryResponse> Handle(GetMyProfileQueryRequest request,
        CancellationToken cancellationToken)
    {
        var userId = long.Parse(_currentUserService.UserId);
        var user = await _uow.GetReadRepository<Domain.Entities.User>().GetByIdAsync(userId);
        if (user == null)
            throw new NotFoundException("$User with {userId} does not exist");
        return new GetMyProfileQueryResponse()
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            RoleName = user.Role.ToString(),
        };
    }
}