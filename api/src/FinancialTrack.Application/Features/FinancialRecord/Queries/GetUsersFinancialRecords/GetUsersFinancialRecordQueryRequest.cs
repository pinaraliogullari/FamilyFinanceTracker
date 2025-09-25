using FinancialTrack.Core.Markers;

namespace FinancialTrack.Application.Features.FinancialRecord.Queries.GetUsersFinancialRecords;

public class GetUsersFinancialRecordQueryRequest:IBaseQueryRequest<List<GetUsersFinancialRecordsQueryResponse>>
{
    public long UserId { get; set; }
}