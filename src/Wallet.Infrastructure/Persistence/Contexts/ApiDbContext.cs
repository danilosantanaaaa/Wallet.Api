using Microsoft.EntityFrameworkCore;

using Wallet.Domain.Carteiras;
using Wallet.Domain.Categorias;
using Wallet.Domain.Cobrancas;
using Wallet.Domain.Common.Interfaces;
using Wallet.Domain.Contatos;
using Wallet.Domain.Users;

namespace Wallet.Infrastructure.Persistence.Contexts;

public sealed class ApiDbContext(DbContextOptions<ApiDbContext> options) : DbContext(options), IUnitOfWork
{
    public DbSet<Carteira> Carteiras => Set<Carteira>();
    public DbSet<Categoria> Categorias => Set<Categoria>();
    public DbSet<Contato> Contatos => Set<Contato>();
    public DbSet<Cobranca> Cobrancas => Set<Cobranca>();
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApiDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}