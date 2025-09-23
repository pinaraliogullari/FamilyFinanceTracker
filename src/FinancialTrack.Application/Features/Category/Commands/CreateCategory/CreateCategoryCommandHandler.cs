using FinancialTrack.Application.DTOs;
using FinancialTrack.Application.Repositories.CategoryRepository;
using FinancialTrack.Application.Services;
using FinancialTrack.Application.Wrappers;
using MediatR;

namespace FinancialTrack.Application.Features.Category.Commands.CreateCategory;

public class
    CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest,
    ApiResult<CreateCategoryCommandResponse>>
{
    private readonly ICategoryService _categoryService;


    public CreateCategoryCommandHandler(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<ApiResult<CreateCategoryCommandResponse>> Handle(CreateCategoryCommandRequest request,
        CancellationToken cancellationToken)
    {
        var createCategoryDto = new CreateCategoryDto()
        {
            Name = request.Name,
            FinancialRecordType = request.FinancialRecordType,
        };
        var newCategory = await _categoryService.CreateCategoryAsync(createCategoryDto);
        var createCategoryCommandResponse = new CreateCategoryCommandResponse()
        {
            Id = newCategory.Id,
            Name = newCategory.Name,
            FinancialRecordType = newCategory.FinancialRecordType,
            IsCustom = newCategory.IsCustom
        };
        return ApiResult<CreateCategoryCommandResponse>.SuccessResult(createCategoryCommandResponse);
    }
}