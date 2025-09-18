using FinancialTrack.Application.Features.Role.Commands.CreateRole;
using MediatR;

namespace FinancialTrack.Application.Features.SubCategory.Commands.CreateSubCategory;

public class CreateSubCategoryCommandRequest:IRequest<CreateSubCategoryCommandResponse>
{
    public string FirstName { get; set; } 
    public string LastName { get; set; }
    public string Email { get; set; } 
    public string Password { get; set; }  
}