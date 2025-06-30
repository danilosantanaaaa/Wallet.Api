namespace Wallet.Application.Common;

public interface IUserProvider
{
    Guid? GetUserId(string token);
    Guid? GetUserId();
}