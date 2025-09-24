using FinancialTrack.Infrastructure.AbstractServices;
using FinancialTrack.Infrastructure.UoW;
using FinancialTrack.Persistence.AbstractRepositories.CategoryRepository;
using FinancialTrack.Persistence.Context;
using MediatR;

namespace FinancialTrack.Application.Features.Category.Commands.CreateCategory;

public class
    CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest,
    CreateCategoryCommandResponse>
{
    private readonly ICategoryWriteRepository _categoryWriteRepository;
    private readonly ICategoryReadRepository _categoryReadRepository;
    private readonly ICurrentUserService _currentUserService;
    private readonly IGenericUnitofWork<FinancialTrackDbContext> _uow;

    public CreateCategoryCommandHandler
    (
        ICategoryWriteRepository categoryWriteRepository,
        ICategoryReadRepository categoryReadRepository,
        ICurrentUserService currentUserService,
        IGenericUnitofWork<FinancialTrackDbContext> uow
    )
    {
        _categoryWriteRepository = categoryWriteRepository;
        _categoryReadRepository = categoryReadRepository;
        _currentUserService = currentUserService;
        _uow = uow;
    }
    public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommandRequest request,
        CancellationToken cancellationToken)
    {
        var existCategory = _categoryReadRepository.GetWhere(x => x.Name ==request.Name, false).FirstOrDefault();
        if (existCategory != null)
            throw new InvalidOperationException("Category already exists");
        var newCategory = new Domain.Entities.Category()
        {
            Name = request.Name,
            IsCustom = !string.IsNullOrEmpty(_currentUserService.UserId),
            FinancialRecordType = request.FinancialRecordType,
        };
        await _categoryWriteRepository.AddAsync(newCategory);
        await _uow.SaveChangesAsync();

        return new CreateCategoryCommandResponse()
        {
            Id = newCategory.Id,
            IsCustom = newCategory.IsCustom,
            Name = newCategory.Name,
            FinancialRecordType = newCategory.FinancialRecordType
        };
    }
}