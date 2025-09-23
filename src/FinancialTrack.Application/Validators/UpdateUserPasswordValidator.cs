using FinancialTrack.Application.Features.User.Commands.UpdateUserPassword;
using FluentValidation;

namespace FinancialTrack.Application.Validators;

public class UpdateUserPasswordValidator : AbstractValidator<UpdateUserPasswordRequest>
{
    public UpdateUserPasswordValidator()
    {
        RuleFor(x => x.OldPassword)
            .NotEmpty().WithMessage("Old password is required.")
            .MinimumLength(6).WithMessage("Old password must be at least 8 characters.");

        RuleFor(x => x.NewPassword)
            .NotEmpty().WithMessage("New password is required.")
            .MinimumLength(6).WithMessage("New password must be at least 8 characters.");

        RuleFor(x => x.NewPasswordConfirm)
            .NotEmpty().WithMessage("New password is required.")
            .Equal(x => x.NewPassword).WithMessage("New password confirmation does not match."); 
    }
   
}