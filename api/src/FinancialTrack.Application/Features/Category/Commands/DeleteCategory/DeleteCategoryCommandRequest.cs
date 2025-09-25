using FinancialTrack.Application.Wrappers;
using FinancialTrack.Core.Markers;
using MediatR;

namespace FinancialTrack.Application.Features.Category.Commands.DeleteCategory;

public class DeleteCategoryCommandRequest:IBaseCommandRequest<DeleteCategoryCommandResponse>
{
    public long CategoryId { get; set; }
}