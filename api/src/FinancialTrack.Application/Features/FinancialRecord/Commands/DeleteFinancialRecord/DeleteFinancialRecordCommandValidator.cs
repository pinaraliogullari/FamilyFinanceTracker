using FluentValidation;

namespace FinancialTrack.Application.Features.FinancialRecord.Commands.DeleteFinancialRecord;

public class DeleteFinancialRecordCommandValidator : AbstractValidator<DeleteFinancialRecordCommandRequest>
{
    public DeleteFinancialRecordCommandValidator()
    {
        RuleFor(x => x.FinancialRecordId)
            .NotEmpty()
            .GreaterThan(0)
            .WithMessage("CategoryId must be greater than zero");
    }
}