using FinancialTrack.Application.Features.Role.Queries.GetAllRoles;
using FinancialTrack.Application.Features.User.Commands.UpdateUserRole;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinancialTrack.API.Controllers;

public class RoleController : BaseController
{
    private readonly IMediator _mediator;

    public RoleController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Route("update-role")]
    public async Task<IActionResult> UpdateRole(UpdateUserRoleCommandRequest request)
    {
        var response = await _mediator.Send(request);
        return HandleApiResponse(response);
    }
    [HttpGet]
    [Route("get-roles")]
    public async Task<IActionResult> GetAllRoles()
    {
        var response = await _mediator.Send(new GetAllRolesQueryRequest());
        return HandleApiResponse(response);
    }
}