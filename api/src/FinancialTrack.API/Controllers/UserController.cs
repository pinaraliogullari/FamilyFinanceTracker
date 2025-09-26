using System.Net;
using FinancialTrack.Application.Features.User.Commands.CreateUser;
using FinancialTrack.Application.Features.User.Commands.DeleteUser;
using FinancialTrack.Application.Features.User.Commands.UpdateUserPassword;
using FinancialTrack.Application.Features.User.Queries.GetAllUsers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinancialTrack.API.Controllers;

public class UserController : BaseController
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpPut]
    public async Task<IActionResult> UpdatePassword([FromBody] UpdateUserPasswordCommandRequest commandRequest)
    {
        var response = await _mediator.Send(commandRequest);
        return HandleApiResponse(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var response = await _mediator.Send(new GetAllUsersQueryRequest());
        return HandleApiResponse(response);
    }

    [HttpDelete]
    [Route("{userId}")]
    public async Task<IActionResult> DeleteUser([FromRoute] long userId)
    {
        var response = await _mediator.Send(new DeleteUserCommandRequest { UserId = userId });
        return HandleApiResponse(response);
    }
}