using FinancialTrack.Core.Markers;
using FinancialTrack.Domain.Entities.Enums;

namespace FinancialTrack.Application.Features.Category.Commands.CreateCategory;

public class CreateCategoryCommandRequest:IBaseCommandRequest<CreateCategoryCommandResponse>
{
    public string Name { get; set; }
    public FinancialRecordType FinancialRecordType { get; set; } 
}