using FinancialTrack.Application.DTOs;
using FinancialTrack.Application.Services;
using FinancialTrack.Application.Wrappers;
using MediatR;

namespace FinancialTrack.Application.Features.Category.Queries.GetCategoriesByType;

public class
    GetCategoriesByTypeQueryHandler : IRequestHandler<GetCategoriesByTypeQueryRequest,ApiResult<GetCategoriesByTypeQueryResponse>>
{
    private readonly ICategoryService _categoryService;

    public GetCategoriesByTypeQueryHandler(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<ApiResult<GetCategoriesByTypeQueryResponse>> Handle(GetCategoriesByTypeQueryRequest request,
        CancellationToken cancellationToken)
    {
        var categories=await _categoryService.GetCategoriesByTypeAsync(request.RecordType);
        var response = new GetCategoriesByTypeQueryResponse()
        {
            Categories = categories.Select(x => new CategoryDto()
            {
                Id = x.Id,
                IsCustom = x.IsCustom,
                Name = x.Name,
                FinancialRecordType = x.FinancialRecordType
            }).ToList()
        };
        return ApiResult<GetCategoriesByTypeQueryResponse>.SuccessResult(response); 
    }
}