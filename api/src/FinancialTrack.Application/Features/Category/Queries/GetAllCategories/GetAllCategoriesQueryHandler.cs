using FinancialTrack.Application.Exceptions;
using FinancialTrack.Core.UoW;
using FinancialTrack.Persistence.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FinancialTrack.Application.Features.Category.Queries.GetAllCategories;

public class
    GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQueryRequest, List<GetAllCategoriesQueryResponse>>
{
    private readonly IGenericUnitofWork<FinancialTrackDbContext> _uow;


    public GetAllCategoriesQueryHandler(IGenericUnitofWork<FinancialTrackDbContext> uow)
    {
        _uow = uow;
    }
    public async Task<List<GetAllCategoriesQueryResponse>> Handle(GetAllCategoriesQueryRequest request,
        CancellationToken cancellationToken)
    {
        var categories = await _uow.GetReadRepository<Domain.Entities.Category>().GetAll(false).ToListAsync();
        if (categories == null || !categories.Any())
            throw new NotFoundException("Any category not found");
        return categories.Select(x => new GetAllCategoriesQueryResponse()
        {
            Id = x.Id,
            IsCustom = x.IsCustom,
            Name = x.Name,
            FinancialRecordType = x.FinancialRecordType
        }).ToList();
    }
}