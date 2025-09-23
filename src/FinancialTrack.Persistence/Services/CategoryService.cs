using FinancialTrack.Application.DTOs;
using FinancialTrack.Application.Exceptions;
using FinancialTrack.Application.Repositories.CategoryRepository;
using FinancialTrack.Application.Services;
using FinancialTrack.Application.UoW;
using FinancialTrack.Domain.Entities;
using FinancialTrack.Domain.Entities.Enums;
using FinancialTrack.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace FinancialTrack.Persistence.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryReadRepository _categoryReadRepository;
    private readonly ICategoryWriteRepository _categoryWriteRepository;
    private readonly IGenericUnitofWork<FinancialTrackDbContext> _uow;
    private readonly ICurrentUserService _currentUserService;

    public CategoryService
    (
        ICategoryReadRepository categoryReadRepository,
        ICategoryWriteRepository categoryWriteRepository,
        IGenericUnitofWork<FinancialTrackDbContext> uow,
        ICurrentUserService currentUserService
    )
    {
        _categoryReadRepository = categoryReadRepository;
        _categoryWriteRepository = categoryWriteRepository;
        _uow = uow;
        _currentUserService = currentUserService;
    }

    public async Task<List<CategoryDto>> GetAllCategoriesAsync()
    {
        var categories = await _categoryReadRepository.GetAll(false).ToListAsync();
        if (categories == null || !categories.Any())
            throw new NotFoundException("Any category not found");
        return categories.Select(x => new CategoryDto()
        {
            Id = x.Id,
            IsCustom = x.IsCustom,
            Name = x.Name,
            FinancialRecordType = x.FinancialRecordType
        }).ToList();
    }

    public async Task<List<CategoryDto>> GetCategoriesByTypeAsync(FinancialRecordType recordType)
    {
        var categories = await _categoryReadRepository.GetWhere(c => c.FinancialRecordType == recordType, false)
            .ToListAsync();
        if (categories == null || !categories.Any())
            throw new NotFoundException("Any category not found");
        return categories.Select(x => new CategoryDto()
        {
            Id = x.Id,
            IsCustom = x.IsCustom,
            Name = x.Name,
            FinancialRecordType = x.FinancialRecordType
        }).ToList();
    }

    public async Task<CategoryDto> CreateCategoryAsync(CreateCategoryDto categoryDto)
    {
        var existCategory = _categoryReadRepository.GetWhere(x => x.Name == categoryDto.Name, false).FirstOrDefault();
        if (existCategory != null)
            throw new InvalidOperationException("Category already exists");
        var newCategory = new Category()
        {
            Name = categoryDto.Name,
            IsCustom = !string.IsNullOrEmpty(_currentUserService.UserId),
            FinancialRecordType = categoryDto.FinancialRecordType,
        };
        await _categoryWriteRepository.AddAsync(newCategory);
        await _uow.SaveChangesAsync();

        return new CategoryDto()
        {
            Id = newCategory.Id,
            IsCustom = newCategory.IsCustom,
            Name = newCategory.Name,
            FinancialRecordType = newCategory.FinancialRecordType
        };
    }
    public async Task DeleteCategoryAsync(long categoryId)
    {
        var category = await _categoryReadRepository.GetByIdAsync(categoryId);
        if (category == null)
            throw new NotFoundException($"Category with id {categoryId} not found");
        _categoryWriteRepository.Remove(category);
        await _uow.SaveChangesAsync();
    }
}