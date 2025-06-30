using System.Security.Cryptography;

using Wallet.Application.Common;
using Wallet.Domain.Users;

namespace Wallet.Infrastructure.Security.Tokens;

internal sealed class RefreshTokenGenerator : ITokenGenerator
{
    public string Generate(User user)
    {
        byte[] randomNumber = new byte[64];
        using RandomNumberGenerator generator = RandomNumberGenerator.Create();
        generator.GetBytes(randomNumber);

        return Convert.ToBase64String(randomNumber);
    }
}
