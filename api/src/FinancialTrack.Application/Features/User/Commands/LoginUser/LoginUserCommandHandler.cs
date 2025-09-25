using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using FinancialTrack.Application.Constants;
using FinancialTrack.Application.Exceptions;
using FinancialTrack.Application.Helpers;
using FinancialTrack.Core.AbstractServices;
using FinancialTrack.Core.UoW;
using FinancialTrack.Persistence.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FinancialTrack.Application.Features.User.Commands.LoginUser;

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
{
    private readonly IGenericUnitofWork<FinancialTrackDbContext> _uow;
    private readonly ITokenService _tokenService;

    public LoginUserCommandHandler(IGenericUnitofWork<FinancialTrackDbContext> uow, ITokenService tokenService)
    {
        _uow = uow;
        _tokenService = tokenService;
    }


    public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request,
        CancellationToken cancellationToken)
    {
        var user = _uow.GetReadRepository<Domain.Entities.User>().GetWhere(x => x.Email == request.Email)
            .FirstOrDefault();
        if (user == null || !PasswordHasher.Verify(request.Password, user.Password))
            throw new AuthenticationFailedException();

        var role = await _uow.GetReadRepository<Domain.Entities.Role>().GetWhere(r => r.Id == user.RoleId)
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