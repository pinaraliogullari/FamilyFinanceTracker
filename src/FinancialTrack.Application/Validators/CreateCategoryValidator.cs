using FinancialTrack.Application.Features.Category.Commands.CreateCategory;
using FluentValidation;

namespace FinancialTrack.Application.Validators;

public class CreateCategoryValidator:AbstractValidator<CreateCategoryCommandRequest>
{
   public CreateCategoryValidator()
   {
      RuleFor(x => x.Name)
         .NotEmpty().WithMessage("Category name cannot be empty.")
         .MaximumLength(100).WithMessage("Category name cannot exceed 100 characters."); // opsiyonel limit

      RuleFor(x => x.FinancialRecordType)
         .IsInEnum().WithMessage("Please specify a financial record type.");
   } 
}