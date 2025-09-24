using FinancialTrack.Application.Exceptions;
using FinancialTrack.Application.Helpers;
using FinancialTrack.Infrastructure.UoW;
using FinancialTrack.Persistence.AbstractRepositories.RoleRepository;
using FinancialTrack.Persistence.AbstractRepositories.UserRepository;
using FinancialTrack.Persistence.Context;
using MediatR;

namespace FinancialTrack.Application.Features.User.Commands.UpdateUserPassword;

public class UpdateUserPasswordHandler:IRequestHandler<UpdateUserPasswordRequest, UpdateUserPasswordResponse>
{
    private readonly IUserWriteRepository _userWriteRepository;
    private readonly IUserReadRepository _userReadRepository;
    private readonly IRoleReadRepository _roleReadRepository;
    private readonly IGenericUnitofWork<FinancialTrackDbContext> _uow;

    public UpdateUserPasswordHandler
    (
        IUserReadRepository userReadRepository,
        IUserWriteRepository userWriteRepository,
        IRoleReadRepository roleReadRepository,
        IGenericUnitofWork<FinancialTrackDbContext> uow
    )
    {
        _userReadRepository = userReadRepository;
        _userWriteRepository = userWriteRepository;
        _roleReadRepository = roleReadRepository;
        _uow = uow;
    } 

    public async Task<UpdateUserPasswordResponse> Handle(UpdateUserPasswordRequest request, CancellationToken cancellationToken)
    {
        var user = await _userReadRepository.GetByIdAsync(request.UserId);
        if (user == null)
            throw new NotFoundException($"User with id {request.UserId} not found");

        if (request.NewPassword != request.NewPasswordConfirm)
            throw new InvalidOperationException("New password and confirm password do not match.");

        if (!PasswordHasher.Verify(request.OldPassword, user.Password))
            throw new UnauthorizedAccessException("Old password is incorrect.");

        user.Password = PasswordHasher.CreateHashPassword(request.NewPassword);
        _userWriteRepository.Update(user);
        await _uow.SaveChangesAsync();
        return new UpdateUserPasswordResponse
        {
            UserId = user.Id,
            IsSuccess = true,
            Message = "Password updated successfully"
        };
    }
}