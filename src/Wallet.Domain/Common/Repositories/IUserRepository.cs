using Wallet.Domain.Users;

namespace Wallet.Domain.Common.Repositories;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetByEmail(string Email);
}