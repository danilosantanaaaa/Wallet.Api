using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

using Wallet.Application.Common;
using Wallet.Domain.Common.Interfaces;
using Wallet.Domain.Users;

namespace Wallet.Infrastructure.Security.Tokens;

internal sealed class JwtTokenGenerator(
    IOptions<JwtSettings> jwtOptions,
    IDateTimeProvider dateTimeProvider) : ITokenGenerator
{
    private readonly JwtSettings _jwtSettings = jwtOptions.Value;
    private readonly IDateTimeProvider _dateTimeProvider = dateTimeProvider;

    public DateTime TokenLifeTime =>
        _dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.TokenLifeTimeInMinutes);

    public string Generate(User user)
    {
        SymmetricSecurityKey key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));

        SigningCredentials credentials = new SigningCredentials(
            key, SecurityAlgorithms.HmacSha256);

        List<Claim> claims = new List<Claim>
        {
            new Claim(nameof(User.Id), user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Name),
            new Claim(ClaimTypes.Email, user.Email),
        };

        DateTime expired = _dateTimeProvider.UtcNow.AddMinutes(
            _jwtSettings.TokenLifeTimeInMinutes);

        JwtSecurityToken jwtToken = new JwtSecurityToken(
            _jwtSettings.Issuer,
            _jwtSettings.Audience,
            claims,
            expires: expired,
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler()
            .WriteToken(jwtToken); ;
    }
}