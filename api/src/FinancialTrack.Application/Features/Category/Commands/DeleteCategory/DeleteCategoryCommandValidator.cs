using FluentValidation;

namespace FinancialTrack.Application.Features.Category.Commands.DeleteCategory;

public class DeleteCategoryCommandValidator : AbstractValidator<DeleteCategoryCommandRequest>
{
    public DeleteCategoryCommandValidator()
    {
        RuleFor(x => x.CategoryId)
            .NotEmpty()
            .GreaterThan(0)
            .WithMessage("CategoryId must be greater than zero");
    }
}