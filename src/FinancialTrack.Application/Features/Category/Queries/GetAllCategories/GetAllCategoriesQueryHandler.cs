using FinancialTrack.Application.DTOs;
using FinancialTrack.Application.Services;
using FinancialTrack.Application.Wrappers;
using MediatR;

namespace FinancialTrack.Application.Features.Category.Queries.GetAllCategories;

public class
    GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQueryRequest,ApiResult<GetAllCategoriesQueryResponse>>
{
    private readonly ICategoryService _categoryService;

    public GetAllCategoriesQueryHandler(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<ApiResult<GetAllCategoriesQueryResponse>> Handle(GetAllCategoriesQueryRequest request,
        CancellationToken cancellationToken)
    {
        var categories=await _categoryService.GetAllCategoriesAsync();
        var response = new GetAllCategoriesQueryResponse()
        {
            Categories = categories.Select(x => new CategoryDto()
            {
                Id = x.Id,
                IsCustom = x.IsCustom,
                Name = x.Name,
                FinancialRecordType = x.FinancialRecordType
            }).ToList()
        };
        return ApiResult<GetAllCategoriesQueryResponse>.SuccessResult(response); 
    }
}