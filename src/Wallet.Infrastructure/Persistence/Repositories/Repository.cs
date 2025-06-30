using System.Diagnostics.CodeAnalysis;

using Microsoft.EntityFrameworkCore;

using Wallet.Domain.Common.Entities;
using Wallet.Domain.Common.Repositories;
using Wallet.Infrastructure.Persistence.Contexts;

namespace Wallet.Infrastructure.Persistence.Repositories;

internal abstract class Repository<TEntity>(ApiDbContext context) : IRepository<TEntity>
    where TEntity : Entity
{
    protected readonly ApiDbContext _context = context;

    public async Task AddAsync([NotNull] TEntity entity, CancellationToken cancellationToken = default)
    {
        await _context
            .Set<TEntity>()
            .AddAsync(entity, cancellationToken);
    }

    public Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = _context.Set<TEntity>().Find(id);
        if (entity == null)
        {
            throw new KeyNotFoundException($"Entity with ID {id} not found.");
        }

        _context
            .Set<TEntity>()
            .Remove(entity);

        return Task.CompletedTask;
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context
            .Set<TEntity>()
            .ToListAsync(cancellationToken);
    }

    public async Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context
            .Set<TEntity>()
            .FindAsync(id, cancellationToken);
    }

    public Task UpdateAsync([NotNull] TEntity entity, CancellationToken cancellationToken = default)
    {
        _context
            .Set<TEntity>()
            .Update(entity);

        return Task.CompletedTask;
    }
}