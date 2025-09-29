
using FinancialTrack.Core.Markers;

namespace FinancialTrack.Application.Features.FinancialRecord.Queries.GetFinancialRecordsByUserId;

public class GetFinancialRecordsByUserIdQueryRequest:IBaseQueryRequest<List<GetFinancialRecordsByUserIdQueryResponse>>
{
    public long UserId { get; set; }
}