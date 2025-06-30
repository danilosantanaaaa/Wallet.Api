namespace Wallet.Application.Common;

public interface IPasswordHashProvider
{
    string Hash(string text);
    bool VerifyPassword(string text, string hash);
}