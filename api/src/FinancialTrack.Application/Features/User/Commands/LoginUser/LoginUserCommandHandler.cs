using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using FinancialTrack.Application.Constants;
using FinancialTrack.Application.Exceptions;
using FinancialTrack.Application.Helpers;
using FinancialTrack.Core.AbstractServices;
using FinancialTrack.Persistence.AbstractRepositories.RoleRepository;
using FinancialTrack.Persistence.AbstractRepositories.UserRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FinancialTrack.Application.Features.User.Commands.LoginUser;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
{
    private readonly IUserReadRepository _userReadRepository;
    private readonly IRoleReadRepository _roleReadRepository;
    private readonly ITokenService _tokenService;

    public LoginUserCommandHandler
    (
        IUserReadRepository userReadRepository,
        IRoleReadRepository roleReadRepository,
        ITokenService tokenService
    )
    {
        _userReadRepository = userReadRepository;
        _roleReadRepository = roleReadRepository;
        _tokenService = tokenService;
    }

    public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request,
        CancellationToken cancellationToken)
    {
        var user = _userReadRepository.GetWhere(x => x.Email == request.Email).FirstOrDefault();
        if (user == null || !PasswordHasher.Verify(request.Password, user.Password))
            throw new AuthenticationFailedException();

        var role = await _roleReadRepository.GetWhere(r => r.Id == user.RoleId)
            .FirstOrDefaultAsync();
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimKey.UserId, user.Id.ToString()),
            new Claim(ClaimKey.Email, user.Email),
            new Claim(ClaimKey.Role, role.Name) 
        };
        var token = await _tokenService.CreateAccessTokenAsync(claims);
        return new LoginUserCommandResponse()
        {
            Token = token,
        };
    }
}