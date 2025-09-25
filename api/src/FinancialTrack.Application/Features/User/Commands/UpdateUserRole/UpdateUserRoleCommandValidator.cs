using FluentValidation;

namespace FinancialTrack.Application.Features.User.Commands.UpdateUserRole;

public class UpdateUserRoleCommandValidator:AbstractValidator<UpdateUserRoleCommandRequest>
{
    public UpdateUserRoleCommandValidator()
    {
        RuleFor(x => x.UserId)
            .GreaterThan(0).WithMessage("UserId must be greater than zero.");

        RuleFor(x => x.RoleId)
            .GreaterThan(0).WithMessage("RoleId must be greater than zero."); 
    }
}