using FinancialTrack.Application.Exceptions;
using FinancialTrack.Core.UoW;
using FinancialTrack.Persistence.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FinancialTrack.Application.Features.Category.Queries.GetCategoriesByType;

public class
    GetCategoriesByTypeQueryHandler : IRequestHandler<GetCategoriesByTypeQueryRequest,
    List<GetCategoriesByTypeQueryResponse>>
{
    private readonly IGenericUnitofWork<FinancialTrackDbContext> _uow;

    public GetCategoriesByTypeQueryHandler(IGenericUnitofWork<FinancialTrackDbContext> uow)
    {
        _uow = uow;
    }

    public async Task<List<GetCategoriesByTypeQueryResponse>> Handle(GetCategoriesByTypeQueryRequest request,
        CancellationToken cancellationToken)
    {
        var categories = await _uow.GetReadRepository<Domain.Entities.Category>()
            .GetWhere(c => c.FinancialRecordType == request.RecordType, false)
            .ToListAsync();
        if (categories == null || !categories.Any())
            throw new NotFoundException("Any category not found");
        return categories.Select(x => new GetCategoriesByTypeQueryResponse()
        {
            Id = x.Id,
            IsCustom = x.IsCustom,
            Name = x.Name,
            FinancialRecordType = x.FinancialRecordType
        }).ToList();
    }
}