using FinancialTrack.Application.Services;
using MediatR;

namespace FinancialTrack.Application.Features.User.Queries.GetAllUsers;

public class GetAllUsersQueryHandler: IRequestHandler<GetAllUsersQueryRequest, GetAllUsersQueryResponse>
{
    private readonly IUserService _userService;

    public GetAllUsersQueryHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<GetAllUsersQueryResponse> Handle(GetAllUsersQueryRequest request, CancellationToken cancellationToken)
    {
        var users= await _userService.GetAllUsersAsync();
        return new GetAllUsersQueryResponse { Users = users }; 
    }
}