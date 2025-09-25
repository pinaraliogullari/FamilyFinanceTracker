using FinancialTrack.Application.Exceptions;
using FinancialTrack.Core.UoW;
using FinancialTrack.Persistence.AbstractRepositories.CategoryRepository;
using FinancialTrack.Persistence.Context;
using MediatR;

namespace FinancialTrack.Application.Features.Category.Commands.DeleteCategory;

public class
    DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandRequest,
    DeleteCategoryCommandResponse>
{
    private readonly ICategoryReadRepository _categoryReadRepository;
    private readonly ICategoryWriteRepository _categoryWriteRepository;
    private readonly IGenericUnitofWork<FinancialTrackDbContext> _uow;

    public DeleteCategoryCommandHandler
    (
        ICategoryReadRepository categoryReadRepository,
        ICategoryWriteRepository categoryWriteRepository,
        IGenericUnitofWork<FinancialTrackDbContext> uow
    )
    {
        _categoryReadRepository = categoryReadRepository;
        _categoryWriteRepository = categoryWriteRepository;
        _uow = uow;
    }


    public async Task<DeleteCategoryCommandResponse> Handle(DeleteCategoryCommandRequest request,
        CancellationToken cancellationToken)
    {
        var category = await _categoryReadRepository.GetByIdAsync(request.CategoryId);
        if (category == null)
            throw new NotFoundException($"Category with id {request.CategoryId} not found");
        _categoryWriteRepository.Remove(category);
        //await _uow.SaveChangesAsync();
        return new DeleteCategoryCommandResponse()
        {
            CategoryId = request.CategoryId
        };
    }
}