using FluentValidation;

namespace FinancialTrack.Application.Features.User.Commands.RefreshToken;

public class RefreshTokenCommandValidator:AbstractValidator<RefreshTokenCommandRequest>
{
    public RefreshTokenCommandValidator()
    {
        RuleFor(x => x.RefreshToken)
            .NotEmpty().WithMessage("Refresh token is required.");

        RuleFor(x => x.ExpiredAccessToken)
            .NotEmpty().WithMessage("Expired access token is required.");
    }
}