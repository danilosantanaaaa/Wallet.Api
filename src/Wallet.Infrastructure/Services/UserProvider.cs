using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

using Wallet.Application.Common;
using Wallet.Domain.Users;
using Wallet.Infrastructure.Security.Tokens;

namespace Wallet.Infrastructure.Services;

internal sealed class UserProvider(
    IOptions<JwtSettings> jwtOptions,
    IHttpContextAccessor httpContextAccessor) : IUserProvider
{
    private readonly JwtSettings _jwtSettings = jwtOptions.Value;
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;

    public Guid? GetUserId(string token)
    {
        try
        {
            TokenValidationParameters validation = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = false,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _jwtSettings.Issuer,
                ValidAudience = _jwtSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey))
            };

            ClaimsPrincipal? claimPrincipal = new JwtSecurityTokenHandler().ValidateToken(token, validation, out _);

            if (claimPrincipal is null)
            {
                return null;
            }

            var userId = claimPrincipal.Claims.FirstOrDefault(u => u.Type == nameof(User.Id));

            return Guid.Parse(userId!.Value);
        }
        catch
        {
            return null;
        }
    }

    public Guid? GetUserId()
    {
        if (_httpContextAccessor.HttpContext is null)
        {
            throw new NullReferenceException();
        }

        return Guid.Parse(GetSingleClaimValues("id"));
    }

    private string GetSingleClaimValues(string claimType)
    {
        return _httpContextAccessor.HttpContext!.User.Claims
            .Single(claim => claim.Type == claimType)
            .Value;
    }
}
