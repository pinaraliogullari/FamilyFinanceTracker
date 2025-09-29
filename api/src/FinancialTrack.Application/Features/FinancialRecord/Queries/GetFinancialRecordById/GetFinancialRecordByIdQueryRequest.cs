using FinancialTrack.Core.Markers;

namespace FinancialTrack.Application.Features.FinancialRecord.Queries.GetFinancialRecordById;

public class GetFinancialRecordByIdQueryRequest:IBaseQueryRequest<GetFinancialRecordByIdQueryResponse>
{
    public long FinancialRecordId { get; set; }
}