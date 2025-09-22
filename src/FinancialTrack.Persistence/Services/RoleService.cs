using FinancialTrack.Application.DTOs;
using FinancialTrack.Application.Exceptions;
using FinancialTrack.Application.Repositories.RoleRepository;
using FinancialTrack.Application.Services;
using Microsoft.EntityFrameworkCore;

namespace FinancialTrack.Persistence.Services;

public class RoleService : IRoleService
{
    private readonly IRoleReadRepository _roleReadRepository;

    public RoleService(IRoleReadRepository roleReadRepository)
    {
        _roleReadRepository = roleReadRepository;
    }

    public async Task<List<RoleDto>> GetAllRolesAsync()
    {
        var roles = await _roleReadRepository.GetAll(false).ToListAsync();
        if (roles == null || !roles.Any())
            throw new NotFoundException("Role not found");
        
        return roles.Select(x => new RoleDto()
        {
            Id = x.Id,
            Name = x.Name,
        }).ToList();
    }
}