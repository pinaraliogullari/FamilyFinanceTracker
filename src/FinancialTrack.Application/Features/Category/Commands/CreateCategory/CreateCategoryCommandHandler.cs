using FinancialTrack.Application.Features.Role.Commands.CreateRole;
using MediatR;

namespace FinancialTrack.Application.Features.Category.Commands.CreateCategory;

public class
    CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommandRequest, CreateCategoryCommandResponse>
{
    public Task<CreateCategoryCommandResponse> Handle(CreateCategoryCommandRequest request,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}