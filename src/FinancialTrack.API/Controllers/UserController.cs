using FinancialTrack.Application.Features.User.Commands.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinancialTrack.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
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
}