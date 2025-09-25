using FinancialTrack.Application.Exceptions;
using FinancialTrack.Core.UoW;
using FinancialTrack.Persistence.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FinancialTrack.Application.Features.User.Queries.GetAllUsers;

public class GetAllUsersQueryHandler: IRequestHandler<GetAllUsersQueryRequest, List<GetAllUsersQueryResponse>>
{
    private readonly IGenericUnitofWork<FinancialTrackDbContext> _uow;

    public GetAllUsersQueryHandler(IGenericUnitofWork<FinancialTrackDbContext> uow)
    {
        _uow = uow;
    }

    public async Task<List<GetAllUsersQueryResponse>> Handle(GetAllUsersQueryRequest request, CancellationToken cancellationToken)
    {
        var users = await _uow.GetReadRepository<Domain.Entities.User>().GetAll(false)
            .Include(x => x.Role).ToListAsync();

        if (users == null || !users.Any())
            throw new NotFoundException("Any user not found");

        return users.Select(x => new GetAllUsersQueryResponse()
        {
            Id = x.Id,
            Firstname = x.FirstName,
            Lastname = x.LastName,
            Email = x.Email,
            RoleName = x.Role.Name,
        }).ToList();
    }
}