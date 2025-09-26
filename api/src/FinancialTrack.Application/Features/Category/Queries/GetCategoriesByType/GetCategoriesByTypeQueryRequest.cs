using FinancialTrack.Core.Markers;
using FinancialTrack.Domain.Entities.Enums;

namespace FinancialTrack.Application.Features.Category.Queries.GetCategoriesByType;

public class GetCategoriesByTypeQueryRequest: IBaseQueryRequest<List<GetCategoriesByTypeQueryResponse>>
{
    public FinancialRecordType RecordType { get; set; }
}