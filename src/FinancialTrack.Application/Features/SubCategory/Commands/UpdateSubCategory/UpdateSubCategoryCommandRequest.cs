using FinancialTrack.Application.Features.User.Commands.UpdateUser;
using MediatR;

namespace FinancialTrack.Application.Features.SubCategory.Commands.UpdateSubCategory;

public class UpdateSubCategoryCommandRequest : IRequest<UpdateSubCategoryCommandResponse>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}