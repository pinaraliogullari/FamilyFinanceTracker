using FinancialTrack.Application.Features.User.Commands.DeleteUser;
using FinancialTrack.Application.Features.User.Commands.UpdateUserPassword;
using FinancialTrack.Application.Features.User.Commands.UpdateUserProfile;
using FinancialTrack.Application.Features.User.Commands.UpdateUserRole;
using FinancialTrack.Application.Features.User.Queries.GetAllUsers;
using FinancialTrack.Application.Features.User.Queries.GetMyProfile;
using FinancialTrack.Application.Features.User.Queries.GetUserById;
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

    [HttpGet]
    [Route("my-profile")]
    public async Task<IApiResult> GetMyProfile()
    {
        var response = await _mediator.Send(new GetMyProfileQueryRequest());
        return HandleApiResponse(response);
    }
    
    [HttpPut]
    [Route("update-profile")]
    public async Task<IApiResult> UpdateProfile([FromBody] UpdateUserProfileCommandRequest request)
    {
        var response= await _mediator.Send(request);
        return HandleApiResponse(response);
    }
    [HttpPut]
    [Route("update-password")]
    public async Task<IApiResult> UpdatePassword([FromBody] UpdateUserPasswordCommandRequest request)
    {
        var response = await _mediator.Send(request);
        return HandleApiResponse(response);
    }
    

    [HttpPut("update-role")]
    public async Task<IApiResult> UpdateRole([FromBody] UpdateUserRoleCommandRequest request)
    {
        var response = await _mediator.Send(request);
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

    [HttpGet]
    [Route("{userId}")]
    public async Task<IApiResult> GetUserById([FromRoute] long userId)
    {
        var response= await _mediator.Send(new GetUserByIdQueryRequest{UserId = userId});
        return HandleApiResponse(response);
    }
}