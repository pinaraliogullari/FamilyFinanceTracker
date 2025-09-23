using FinancialTrack.Application.Services;
using FinancialTrack.Application.Wrappers;
using MediatR;

namespace FinancialTrack.Application.Features.Category.Commands.DeleteCategory;

public class
    DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandRequest,
    ApiResult<DeleteCategoryCommandResponse>>
{
    private readonly ICategoryService _categoryService;

    public DeleteCategoryCommandHandler(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<ApiResult<DeleteCategoryCommandResponse>> Handle(DeleteCategoryCommandRequest request,
        CancellationToken cancellationToken)
    {
        await _categoryService.DeleteCategoryAsync(request.CategoryId);
        var deleteCategoryCommandResponse = new DeleteCategoryCommandResponse()
        {
            CategoryId = request.CategoryId
        };
        return ApiResult<DeleteCategoryCommandResponse>.SuccessResult(deleteCategoryCommandResponse);
    }
}