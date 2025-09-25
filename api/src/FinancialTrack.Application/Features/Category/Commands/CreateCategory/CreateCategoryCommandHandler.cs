using FinancialTrack.Core.AbstractServices;
using FinancialTrack.Core.UoW;
using FinancialTrack.Persistence.Context;
using MediatR;

namespace FinancialTrack.Application.Features.Category.Commands.CreateCategory;

public class
    CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest,
    CreateCategoryCommandResponse>
{
   
    private readonly ICurrentUserService _currentUserService;
    private readonly IGenericUnitofWork<FinancialTrackDbContext> _uow;

    public CreateCategoryCommandHandler
    (
        ICurrentUserService currentUserService,
        IGenericUnitofWork<FinancialTrackDbContext> uow
    )
    {
        _currentUserService = currentUserService;
        _uow = uow;
    }
    public async Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommandRequest request,
        CancellationToken cancellationToken)
    {
        var existCategory = _uow.GetReadRepository<Domain.Entities.Category>().GetWhere(x => x.Name ==request.Name, false).FirstOrDefault();
        if (existCategory != null)
            throw new InvalidOperationException("Category already exists");
        var newCategory = new Domain.Entities.Category()
        {
            Name = request.Name,
            IsCustom = !string.IsNullOrEmpty(_currentUserService.UserId),
            FinancialRecordType = request.FinancialRecordType,
        };
        await _uow.GetWriteRepository<Domain.Entities.Category>().AddAsync(newCategory);

        return new CreateCategoryCommandResponse()
        {
            Id = newCategory.Id,
            IsCustom = newCategory.IsCustom,
            Name = newCategory.Name,
            FinancialRecordType = newCategory.FinancialRecordType
        };
    }
}