using FinancialTrack.Application.Exceptions;
using FinancialTrack.Persistence.AbstractRepositories.RoleRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FinancialTrack.Application.Features.Role.Queries.GetAllRoles;

public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQueryRequest, List<GetAllRolesQueryResponse>>
{
    private readonly IRoleReadRepository _roleReadRepository;

    public GetAllRolesQueryHandler(IRoleReadRepository roleReadRepository)
    {
        _roleReadRepository = roleReadRepository;
    }

    public async Task<List<GetAllRolesQueryResponse>> Handle(GetAllRolesQueryRequest request,
        CancellationToken cancellationToken)
    {
        var roles = await _roleReadRepository.GetAll(false).ToListAsync();
        if (roles == null || !roles.Any())
            throw new NotFoundException("Role not found");

        return roles.Select(x => new GetAllRolesQueryResponse()
        {
            Id = x.Id,
            Name = x.Name,
        }).ToList();
    }
}