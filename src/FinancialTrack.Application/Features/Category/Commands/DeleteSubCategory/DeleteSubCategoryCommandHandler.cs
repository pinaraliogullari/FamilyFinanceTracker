using FinancialTrack.Application.Features.Role.Commands.DeleteRole;
using MediatR;

namespace FinancialTrack.Application.Features.SubCategory.Commands.DeleteSubCategory;

public class DeleteSubCategoryCommandHandler: IRequestHandler<DeleteSubCategoryCommandRequest, DeleteSubCategoryCommandResponse>
{
    public Task<DeleteSubCategoryCommandResponse> Handle(DeleteSubCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}