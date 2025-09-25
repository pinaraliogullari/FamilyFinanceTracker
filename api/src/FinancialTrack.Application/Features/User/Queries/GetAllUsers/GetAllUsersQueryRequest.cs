using FinancialTrack.Application.Markers;
using FinancialTrack.Application.Wrappers;
using FinancialTrack.Core.Markers;
using MediatR;

namespace FinancialTrack.Application.Features.User.Queries.GetAllUsers;

public class GetAllUsersQueryRequest: IBaseQueryRequest<List<GetAllUsersQueryResponse>>
{
    
}