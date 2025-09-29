using FinancialTrack.Core.Markers;
using FinancialTrack.Domain.Entities.Enums;

namespace FinancialTrack.Application.Features.FinancialRecord.Queries.GetFinancialRecordsByType;

public class GetFinancialRecordsByTypeQueryRequest:IBaseQueryRequest<List<GetFinancialRecordsByTypeQueryResponse>>
{
    public FinancialRecordType FinancialRecordType { get; set; }
}