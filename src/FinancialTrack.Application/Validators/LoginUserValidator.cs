using FinancialTrack.Application.Features.User.Commands.LoginUser;
using FluentValidation;

namespace FinancialTrack.Application.Validators;

public class LoginUserValidator:AbstractValidator<LoginUserCommandRequest>
{
    public LoginUserValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Invalid email format");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required");
    }
}