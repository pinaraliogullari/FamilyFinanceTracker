using FinancialTrack.Application.DTOs;
using FinancialTrack.Domain.Entities.Enums;

namespace FinancialTrack.Application.Services;

public interface ICategoryService
{
    Task<List<CategoryDto>> GetAllCategoriesAsync();
    Task<List<CategoryDto>> GetCategoriesByTypeAsync(FinancialRecordType recordType);
    Task<CategoryDto>CreateCategoryAsync(CreateCategoryDto categoryDto);
    Task DeleteCategoryAsync(long categoryId);

}