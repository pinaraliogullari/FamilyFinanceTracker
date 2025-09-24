using FinancialTrack.Application.Exceptions;
using FinancialTrack.Persistence.AbstractRepositories.CategoryRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FinancialTrack.Application.Features.Category.Queries.GetAllCategories;

public class
    GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQueryRequest,List<GetAllCategoriesQueryResponse>>
{
    private readonly ICategoryReadRepository _categoryReadRepository;

    public GetAllCategoriesQueryHandler(ICategoryReadRepository categoryReadRepository)
    {
        _categoryReadRepository = categoryReadRepository;
    }

    public async Task<List<GetAllCategoriesQueryResponse>> Handle(GetAllCategoriesQueryRequest request,
        CancellationToken cancellationToken)
    {
        var categories = await _categoryReadRepository.GetAll(false).ToListAsync();
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