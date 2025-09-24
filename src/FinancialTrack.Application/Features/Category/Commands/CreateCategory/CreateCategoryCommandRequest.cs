using FinancialTrack.Application.Features.Role.Commands.CreateRole;
using FinancialTrack.Application.Wrappers;
using FinancialTrack.Domain.Entities.Enums;
using MediatR;

namespace FinancialTrack.Application.Features.Category.Commands.CreateCategory;

public class CreateCategoryCommandRequest:IRequest<CreateCategoryCommandResponse>
{
    public string Name { get; set; }
    public FinancialRecordType FinancialRecordType { get; set; } 
}