using FluentValidation;

namespace FinancialTrack.Application.Features.User.Commands.DeleteUser;

public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommandRequest>
{
    public DeleteUserCommandValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .GreaterThan(0)
            .WithMessage("UserId must be greater than zero");
    }
}