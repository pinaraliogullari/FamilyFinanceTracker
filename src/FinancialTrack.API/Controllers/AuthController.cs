using FinancialTrack.Application.Features.User.Commands.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinancialTrack.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login(LoginUserCommandRequest request)
    {
        var response=await _mediator.Send(request);
        return Ok(response);
    }
}