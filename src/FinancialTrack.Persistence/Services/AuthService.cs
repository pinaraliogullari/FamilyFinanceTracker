using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using FinancialTrack.Application.Constants;
using FinancialTrack.Application.DTOs;
using FinancialTrack.Application.Exceptions;
using FinancialTrack.Application.Helpers;
using FinancialTrack.Application.Repositories.RoleRepository;
using FinancialTrack.Application.Repositories.UserRepository;
using FinancialTrack.Application.Services;
using Microsoft.EntityFrameworkCore;

namespace FinancialTrack.Persistence.Services;

public class AuthService : IAuthService
{
    public AuthService(IUserReadRepository userReadRepository, IRoleReadRepository roleReadRepository, ITokenService tokenService)
    {
        _userReadRepository = userReadRepository;
        _roleReadRepository = roleReadRepository;
        _tokenService = tokenService;
    }

    private readonly IUserReadRepository _userReadRepository;
    private readonly IRoleReadRepository _roleReadRepository;
    private readonly ITokenService _tokenService;

    public async Task<LoginUserResponse> LoginAsync(LoginUser model)
    {
        var user = _userReadRepository.GetWhere(x => x.Email == model.Email).FirstOrDefault();
        if (user == null || !PasswordHasher.Verify(model.Password, user.Password))
            throw new AuthenticationFailedException();
        
        var role = await _roleReadRepository.GetWhere(r => r.Id == user.RoleId)
            .FirstOrDefaultAsync();
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimKey.UserId, user.Id.ToString()),
            new Claim(ClaimKey.Email, user.Email),
            new Claim(ClaimKey.Role, role.Name)//burası null olduğu için token servise girmiyor olabilir
        };
        var token = await _tokenService.CreateAccessTokenAsync(claims);
        return new LoginUserResponse()
        {
            Token = token,
        };
    }

    public Task LogoutAsync()
    {
        throw new NotImplementedException();
    }
}