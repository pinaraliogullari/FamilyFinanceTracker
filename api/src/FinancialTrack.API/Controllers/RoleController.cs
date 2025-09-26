using FinancialTrack.Application.Features.Role.Queries.GetAllRoles;
using FinancialTrack.Application.Features.User.Commands.UpdateUserRole;
using FinancialTrack.Core.Results;
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

    [HttpPut]
    public async Task<IApiResult> UpdateRole([FromBody]UpdateUserRoleCommandRequest request)
    {
        var response = await _mediator.Send(request);
        return HandleApiResponse(response);
    }
    [HttpGet]
    public async Task<IApiResult> GetAllRoles()
    {
        var response = await _mediator.Send(new GetAllRolesQueryRequest());
        return HandleApiResponse(response);
    }
}