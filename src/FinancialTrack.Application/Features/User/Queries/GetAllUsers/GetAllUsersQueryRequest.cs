using FinancialTrack.Application.Wrappers;
using MediatR;

namespace FinancialTrack.Application.Features.User.Queries.GetAllUsers;

public class GetAllUsersQueryRequest: IRequest<ApiResult<GetAllUsersQueryResponse>>
{
    
}