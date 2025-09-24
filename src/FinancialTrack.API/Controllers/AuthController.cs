using FinancialTrack.Application.Features.User.Commands.LoginUser;
using FinancialTrack.Application.Features.User.Commands.LogoutUser;
using FinancialTrack.Application.Features.User.Commands.RefreshToken;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinancialTrack.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : BaseController
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
    [HttpPost]
    [Route("logout")]
    public async Task<IActionResult> Login(LogoutUserCommandRequest request)
    {
        var response=await _mediator.Send(request);
        return Ok(response);
    }
    [HttpPost]
    [Route("refresh-token")]
    public async Task<IActionResult> LoginByRefreshToken(RefreshTokenCommandRequest request)
    {
        var response=await _mediator.Send(request);
        return Ok(response);
    }
}