using FinancialTrack.Application.DTOs;

namespace FinancialTrack.Application.Services;

public interface IUserService
{
    Task<CreateUserResponse> CreateUserAsync(CreateUser model);
}