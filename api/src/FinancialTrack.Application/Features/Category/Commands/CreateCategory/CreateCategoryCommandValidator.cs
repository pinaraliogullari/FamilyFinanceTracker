using FinancialTrack.Application.Features.Category.Commands.CreateCategory;
using FluentValidation;

namespace FinancialTrack.Application.Features.Category.Commands.CreateCategory;

public class CreateCategoryCommandValidator:AbstractValidator<CreateCategoryCommandRequest>
{
   public CreateCategoryCommandValidator()
   {
      RuleFor(x => x.Name)
         .NotEmpty().WithMessage("Category name cannot be empty.")
         .MaximumLength(100).WithMessage("Category name cannot exceed 100 characters."); // opsiyonel limit

      RuleFor(x => x.FinancialRecordType)
         .IsInEnum().WithMessage("Please specify a financial record type.");
   } 
}