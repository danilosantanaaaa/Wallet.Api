using Wallet.Application.Common;

using static BCrypt.Net.BCrypt;

namespace Wallet.Infrastructure.Security.PasswordHashers;

internal sealed class PasswordHashProvider : IPasswordHashProvider
{
    public string Hash(string text)
    {
        return HashPassword(text);
    }

    public bool VerifyPassword(string text, string hash)
    {
        return Verify(text, hash);
    }
}
