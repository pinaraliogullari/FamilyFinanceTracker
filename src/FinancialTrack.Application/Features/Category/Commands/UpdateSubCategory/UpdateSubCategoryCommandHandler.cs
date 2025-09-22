using FinancialTrack.Application.Features.Role.Commands.UpdateRole;
using FinancialTrack.Application.Features.User.Commands.UpdateUser;
using MediatR;

namespace FinancialTrack.Application.Features.SubCategory.Commands.UpdateSubCategory;

public class UpdateSubCategoryCommandHandler : IRequestHandler<UpdateSubCategoryCommandRequest, UpdateSubCategoryCommandResponse>
{
    public Task<UpdateSubCategoryCommandResponse> Handle(UpdateSubCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}