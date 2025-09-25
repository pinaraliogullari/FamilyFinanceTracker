using FluentValidation;

namespace FinancialTrack.Application.Features.FinancialRecord.Commands.CreateFinancialRecord;

public class CreateFinancialRecordCommandValidator:AbstractValidator<CreateFinancialRecordCommandRequest>
{
    public CreateFinancialRecordCommandValidator()
    {
        RuleFor(x => x.Amount)
            .GreaterThan(0).WithMessage("Amount must be greater than zero.");

        RuleFor(x => x.CategoryId)
            .GreaterThan(0).WithMessage("CategoryId must be a valid ID.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required.")
            .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");

        RuleFor(x => x.UserId)
            .GreaterThan(0).WithMessage("UserId must be a valid ID."); 
    }
}