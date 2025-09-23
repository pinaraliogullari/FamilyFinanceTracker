using FinancialTrack.Application.Markers;
using FinancialTrack.Application.Wrappers;
using FinancialTrack.Domain.Entities.Enums;
using MediatR;

namespace FinancialTrack.Application.Features.Category.Queries.GetCategoriesByType;

public class GetCategoriesByTypeQueryRequest: IBaseQueryRequest<ApiResult<GetCategoriesByTypeQueryResponse>>
{
    public FinancialRecordType RecordType { get; set; }
}