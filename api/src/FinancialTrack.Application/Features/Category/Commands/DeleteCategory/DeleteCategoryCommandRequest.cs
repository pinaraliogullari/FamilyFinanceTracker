using FinancialTrack.Application.Wrappers;
using MediatR;

namespace FinancialTrack.Application.Features.Category.Commands.DeleteCategory;

public class DeleteCategoryCommandRequest:IRequest<DeleteCategoryCommandResponse>
{
    public long CategoryId { get; set; }
}