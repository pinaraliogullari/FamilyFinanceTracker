using FinancialTrack.Application.Exceptions;
using FinancialTrack.Core.UoW;
using FinancialTrack.Persistence.Context;
using MediatR;

namespace FinancialTrack.Application.Features.Category.Commands.DeleteCategory;

public class
    DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommandRequest,
    DeleteCategoryCommandResponse>
{
    private readonly IGenericUnitofWork<FinancialTrackDbContext> _uow;

    public DeleteCategoryCommandHandler(IGenericUnitofWork<FinancialTrackDbContext> uow)
    {
        _uow = uow;
    }

    public async Task<DeleteCategoryCommandResponse> Handle(DeleteCategoryCommandRequest request,
        CancellationToken cancellationToken)
    {
        var category = await _uow.GetReadRepository<Domain.Entities.Category>().GetByIdAsync(request.CategoryId);
        if (category == null)
            throw new NotFoundException($"Category with id {request.CategoryId} not found");
        _uow.GetWriteRepository<Domain.Entities.Category>().Remove(category);
        return new DeleteCategoryCommandResponse()
        {
            CategoryId = request.CategoryId
        };
    }
}