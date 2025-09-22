using FinancialTrack.Application.Features.Role.Commands.CreateRole;
using MediatR;

namespace FinancialTrack.Application.Features.Category.Commands.CreateCategory;

public class CreateCategoryCommandRequest:IRequest<CreateCategoryCommandResponse>
{
    public string FirstName { get; set; } 
    public string LastName { get; set; }
    public string Email { get; set; } 
    public string Password { get; set; }  
}