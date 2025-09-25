using FinancialTrack.Core.Markers;

namespace FinancialTrack.Application.Features.FinancialRecord.Queries.GetByIdFinancialRecord;

public class GetByIdFinancialRecordQueryRequest:IBaseQueryRequest<GetByIdFinancialRecordQueryResponse>
{
    public long FinancialRecordId { get; set; }
}