using FinancialTrack.Application.Exceptions;
using FinancialTrack.Core.UoW;
using FinancialTrack.Persistence.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FinancialTrack.Application.Features.Role.Queries.GetAllRoles;

public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQueryRequest, List<GetAllRolesQueryResponse>>
{
    private readonly IGenericUnitofWork<FinancialTrackDbContext> _uow;

    public GetAllRolesQueryHandler(IGenericUnitofWork<FinancialTrackDbContext> uow)
    {
        _uow = uow;
    }

    public async Task<List<GetAllRolesQueryResponse>> Handle(GetAllRolesQueryRequest request,
        CancellationToken cancellationToken)
    {
        var roles = await _uow.GetReadRepository<Domain.Entities.Role>().GetAll(false).ToListAsync();
        if (roles == null || !roles.Any())
            throw new NotFoundException("Role not found");

        return roles.Select(x => new GetAllRolesQueryResponse()
        {
            Id = x.Id,
            Name = x.Name,
        }).ToList();
    }
}