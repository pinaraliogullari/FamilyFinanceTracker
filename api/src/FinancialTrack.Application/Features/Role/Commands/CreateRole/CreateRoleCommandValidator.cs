using FluentValidation;

namespace FinancialTrack.Application.Features.Role.Commands.CreateRole;

public class CreateRoleCommandValidator:AbstractValidator<CreateRoleCommandRequest>
{
    public CreateRoleCommandValidator()
    {

    }
}