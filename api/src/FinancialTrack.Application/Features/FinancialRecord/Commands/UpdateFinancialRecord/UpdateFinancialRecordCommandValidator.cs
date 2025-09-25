using FluentValidation;

namespace FinancialTrack.Application.Features.FinancialRecord.Commands.UpdateFinancialRecord;

public class UpdateFinancialRecordCommandValidator : AbstractValidator<UpdateFinancialRecordCommandRequest>
{
    public UpdateFinancialRecordCommandValidator()
    {
        RuleFor(x => x.FinancialRecordId)
            .GreaterThan(0).WithMessage("FinancialRecordId must be greater than zero.");
        
        When(x => x.Amount.HasValue, () =>
        {
            RuleFor(x => x.Amount.Value)
                .GreaterThan(0).WithMessage("Amount must be greater than zero.");
        });

        When(x => x.CategoryId.HasValue, () =>
        {
            RuleFor(x => x.CategoryId.Value)
                .GreaterThan(0).WithMessage("CategoryId must be a valid ID.");
        });

        When(x => x.UserId.HasValue, () =>
        {
            RuleFor(x => x.UserId.Value)
                .GreaterThan(0).WithMessage("UserId must be a valid ID.");
        });
        
        When(x => !string.IsNullOrEmpty(x.Description), () =>
        {
            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");
        });
    }
}