using FinancialTrack.Application.Features.Role.Commands.CreateRole;
using MediatR;

namespace FinancialTrack.Application.Features.SubCategory.Commands.CreateSubCategory;

public class
    CreateSubCategoryCommandHandler : IRequestHandler<CreateSubCategoryCommandRequest, CreateSubCategoryCommandResponse>
{
    public Task<CreateSubCategoryCommandResponse> Handle(CreateSubCategoryCommandRequest request,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}