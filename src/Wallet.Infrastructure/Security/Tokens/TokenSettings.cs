namespace Wallet.Infrastructure.Security.Tokens;

public class JwtSettings
{
    public const string SectionName = nameof(JwtSettings);
    public string Audience { get; init; }
    public string Issuer { get; init; }
    public string SecretKey { get; init; }
    public int TokenLifeTimeInMinutes { get; init; }
}