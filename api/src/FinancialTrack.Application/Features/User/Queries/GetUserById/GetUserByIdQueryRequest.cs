using FinancialTrack.Application.Features.User.Queries.GetByIdUser;
using FinancialTrack.Core.Markers;

namespace FinancialTrack.Application.Features.User.Queries.GetUserById;

public class GetUserByIdQueryRequest:IBaseQueryRequest<GetUserByIdQueryResponse>
{
    public long UserId { get; set; }        
}