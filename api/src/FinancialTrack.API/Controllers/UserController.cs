using FinancialTrack.Application.Features.User.Commands.DeleteUser;
using FinancialTrack.Application.Features.User.Commands.UpdateUserPassword;
using FinancialTrack.Application.Features.User.Queries.GetAllUsers;
using FinancialTrack.Core.Results;
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
    public async Task<IApiResult> UpdatePassword([FromBody] UpdateUserPasswordCommandRequest commandRequest)
    {
        var response = await _mediator.Send(commandRequest);
        return HandleApiResponse(response);
    }

    [HttpGet]
    public async Task<IApiResult> GetAllUsers()
    {
        var response = await _mediator.Send(new GetAllUsersQueryRequest());
        return HandleApiResponse(response);
    }

    [HttpDelete]
    [Route("{userId}")]
    public async Task<IApiResult> DeleteUser([FromRoute] long userId)
    {
        var response = await _mediator.Send(new DeleteUserCommandRequest { UserId = userId });
        return HandleApiResponse(response);
    }
}