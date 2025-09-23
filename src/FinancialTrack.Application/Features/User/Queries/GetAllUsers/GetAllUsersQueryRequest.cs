using FinancialTrack.Application.Markers;
using FinancialTrack.Application.Wrappers;
using MediatR;

namespace FinancialTrack.Application.Features.User.Queries.GetAllUsers;

public class GetAllUsersQueryRequest: IBaseQueryRequest<ApiResult<GetAllUsersQueryResponse>>
{
    
}