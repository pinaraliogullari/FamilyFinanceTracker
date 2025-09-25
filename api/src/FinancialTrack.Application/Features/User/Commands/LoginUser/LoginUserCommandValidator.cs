using FinancialTrack.Application.Features.User.Commands.LoginUser;
using FluentValidation;

namespace FinancialTrack.Application.Features.User.Commands.LoginUser;

public class LoginUserCommandValidator:AbstractValidator<LoginUserCommandRequest>
{
    public LoginUserCommandValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Invalid email format");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required");
    }
}