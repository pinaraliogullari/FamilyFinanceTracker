using FinancialTrack.Application.Markers;
using FinancialTrack.Application.Wrappers;
using FinancialTrack.Core.Markers;
using FinancialTrack.Domain.Entities.Enums;
using MediatR;

namespace FinancialTrack.Application.Features.Category.Queries.GetCategoriesByType;

public class GetCategoriesByTypeQueryRequest: IBaseQueryRequest<List<GetCategoriesByTypeQueryResponse>>
{
    public FinancialRecordType RecordType { get; set; }
}