using System.Net;
using FinancialTrack.Application.Features.User.Commands.CreateUser;
using FinancialTrack.Application.Features.User.Commands.LoginUser;
using FinancialTrack.Application.Features.User.Commands.LogoutUser;
using FinancialTrack.Application.Features.User.Commands.RefreshToken;
using FinancialTrack.Core.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinancialTrack.API.Controllers;

public class AuthController : BaseController
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpPost]
    [Route("register")]
    public async Task<IApiResult> CreateUser([FromBody]CreateUserCommandRequest request)
    {
        var response=await _mediator.Send(request);
        return HandleApiResponse(response,httpStatusCode:HttpStatusCode.Created);
    }
    [HttpPost]
    [Route("login")]
    public async Task<IApiResult> Login([FromBody]LoginUserCommandRequest request)
    {
        var response=await _mediator.Send(request);
        return HandleApiResponse(response);
    }
    [HttpPost]
    [Route("logout")]
    public async Task<IApiResult> Logout()
    {
        var response=await _mediator.Send(new LogoutUserCommandRequest());
        return HandleApiResponse(response);
    }
    [HttpPost]
    [Route("refresh-token")]
    public async Task<IApiResult> LoginByRefreshToken([FromBody]RefreshTokenCommandRequest request)
    {
        var response=await _mediator.Send(request);
        return HandleApiResponse(response);
    }
    
}