using FinancialTrack.Application.DTOs;
using FinancialTrack.Application.Exceptions;
using FinancialTrack.Application.Repositories.UserRepository;
using FinancialTrack.Application.Services;

namespace FinancialTrack.Persistence.Services;

public class AuthService : IAuthService
{
    private readonly IUserReadRepository _userReadRepository;
    private readonly ITokenService _tokenService;

    public AuthService(IUserReadRepository userReadRepository, ITokenService tokenService)
    {
        _userReadRepository = userReadRepository;
        _tokenService = tokenService;
    }

    public async Task<LoginUserResponse> LoginAsync(LoginUser model)
    {
        var user = _userReadRepository.GetWhere(x => x.Email == model.Email).FirstOrDefault();
        if (user == null)
            throw new NotFoundUserException();
        throw new NotImplementedException();
    }
}