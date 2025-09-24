using FinancialTrack.Application.Features.User.Commands.CreateUser;
using FinancialTrack.Application.Features.User.Commands.DeleteUser;
using FinancialTrack.Application.Features.User.Commands.UpdateUserPassword;
using FinancialTrack.Application.Features.User.Queries.GetAllUsers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinancialTrack.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : BaseController
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Route("create-user")]
    public async Task<IActionResult> CreateUser(CreateUserCommandRequest request)
    {
        var response=await _mediator.Send(request);
        return Ok(response);
    }
    [HttpPost]
    [Route("update-password")]
    public async Task<IActionResult> UpdatePassword(UpdateUserPasswordRequest request)
    {
        var response=await _mediator.Send(request);
        return Ok(response);
    }
    [HttpGet]
    [Route("get-users")]
    public async Task<IActionResult> GetAllUsers()
    {
        var response=await _mediator.Send(new  GetAllUsersQueryRequest());
        return Ok(response);
    }
    [HttpDelete]
    [Route("delete-user/{userId}")]
    public async Task<IActionResult> DeleteUser([FromRoute] long userId)
    {
        var response=await _mediator.Send(new DeleteUserCommandRequest{UserId=userId});
        return Ok(response);
    }
}