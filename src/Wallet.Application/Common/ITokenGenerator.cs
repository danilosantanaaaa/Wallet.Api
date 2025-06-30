using Wallet.Domain.Users;

namespace Wallet.Application.Common;

public interface ITokenGenerator
{
    string Generate(User user);
}