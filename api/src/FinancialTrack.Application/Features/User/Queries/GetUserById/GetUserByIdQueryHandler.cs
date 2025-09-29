using FinancialTrack.Application.Exceptions;
using FinancialTrack.Application.Features.User.Queries.GetByIdUser;
using FinancialTrack.Core.UoW;
using FinancialTrack.Persistence.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FinancialTrack.Application.Features.User.Queries.GetUserById;

public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQueryRequest, GetUserByIdQueryResponse>
{
    private readonly IGenericUnitofWork<FinancialTrackDbContext> _uow;

    public GetUserByIdQueryHandler(IGenericUnitofWork<FinancialTrackDbContext> uow)
    {
        _uow = uow;
    }

    public async Task<GetUserByIdQueryResponse> Handle(GetUserByIdQueryRequest request,
        CancellationToken cancellationToken)
    {
        var user = await _uow.GetReadRepository<Domain.Entities.User>()
            .GetAll() 
            .Include(u => u.Role) 
            .FirstOrDefaultAsync(u => u.Id == request.UserId, cancellationToken);
        if (user == null)
            throw new NotFoundException("$User with {userId} does not exist");
        return new GetUserByIdQueryResponse()
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            RoleName = user.Role.Name,
            RoleId = user.RoleId,
        };
    }
}