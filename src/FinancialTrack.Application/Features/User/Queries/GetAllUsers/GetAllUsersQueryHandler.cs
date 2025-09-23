using FinancialTrack.Application.DTOs;
using FinancialTrack.Application.Services;
using FinancialTrack.Application.Wrappers;
using MediatR;

namespace FinancialTrack.Application.Features.User.Queries.GetAllUsers;

public class GetAllUsersQueryHandler: IRequestHandler<GetAllUsersQueryRequest, ApiResult<GetAllUsersQueryResponse>>
{
    private readonly IUserService _userService;

    public GetAllUsersQueryHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<ApiResult<GetAllUsersQueryResponse>> Handle(GetAllUsersQueryRequest request, CancellationToken cancellationToken)
    {
        var users= await _userService.GetAllUsersAsync();
        var response = new GetAllUsersQueryResponse()
        {
            Users = users.Select(x => new UserDto()
            {
                Email = x.Email,
                Firstname = x.Firstname,
                Lastname = x.Lastname,
                Id = x.Id,
                RoleName = x.RoleName
            }).ToList()
        };
        return  ApiResult<GetAllUsersQueryResponse>.SuccessResult(response); 
    }
}