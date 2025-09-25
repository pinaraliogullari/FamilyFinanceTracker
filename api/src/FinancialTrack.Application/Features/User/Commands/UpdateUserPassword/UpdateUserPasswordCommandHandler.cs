using FinancialTrack.Application.Exceptions;
using FinancialTrack.Application.Helpers;
using FinancialTrack.Core.UoW;
using FinancialTrack.Persistence.Context;
using MediatR;

namespace FinancialTrack.Application.Features.User.Commands.UpdateUserPassword;

public class
    UpdateUserPasswordCommandHandler : IRequestHandler<UpdateUserPasswordCommandRequest,
    UpdateUserPasswordCommandResponse>
{
    private readonly IGenericUnitofWork<FinancialTrackDbContext> _uow;


    public UpdateUserPasswordCommandHandler(IGenericUnitofWork<FinancialTrackDbContext> uow)
    {
        _uow = uow;
    }

    public async Task<UpdateUserPasswordCommandResponse> Handle(UpdateUserPasswordCommandRequest commandRequest,
        CancellationToken cancellationToken)
    {
        var user = await _uow.GetReadRepository<Domain.Entities.User>().GetByIdAsync(commandRequest.UserId);
        if (user == null)
            throw new NotFoundException($"User with id {commandRequest.UserId} not found");

        if (commandRequest.NewPassword != commandRequest.NewPasswordConfirm)
            throw new InvalidOperationException("New password and confirm password do not match.");

        if (!PasswordHasher.Verify(commandRequest.OldPassword, user.Password))
            throw new UnauthorizedAccessException("Old password is incorrect.");

        user.Password = PasswordHasher.CreateHashPassword(commandRequest.NewPassword);
        _uow.GetWriteRepository<Domain.Entities.User>().Update(user);
        return new UpdateUserPasswordCommandResponse
        {
            UserId = user.Id,
            IsSuccess = true,
            Message = "Password updated successfully"
        };
    }
}