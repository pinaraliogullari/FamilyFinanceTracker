using FinancialTrack.Core.Markers;

namespace FinancialTrack.Application.Features.Category.Commands.DeleteCategory;

public class DeleteCategoryCommandRequest:IBaseCommandRequest<DeleteCategoryCommandResponse>
{
    public long CategoryId { get; set; }
}