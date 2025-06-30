using Microsoft.EntityFrameworkCore;

using Wallet.Domain.Common.Repositories;
using Wallet.Domain.Users;
using Wallet.Infrastructure.Persistence.Contexts;

namespace Wallet.Infrastructure.Persistence.Repositories;

internal sealed class UserRepository(ApiDbContext context) : Repository<User>(context), IUserRepository
{
    public async Task<User?> GetByEmail(string email)
    {
        return await _context.Set<User>()
            .FirstOrDefaultAsync(u =>
                u.Email.ToLower()
                    .Equals(email.ToLower()));
    }
}
