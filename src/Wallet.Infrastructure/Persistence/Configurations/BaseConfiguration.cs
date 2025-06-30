using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Wallet.Domain.Common.Entities;

namespace Wallet.Infrastructure.Persistence.Configurations;

internal abstract class BaseConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
    where TEntity : Entity
{
    public virtual void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder
            .Property(e => e.Id)
            .IsRequired()
            .ValueGeneratedNever();

        builder
            .HasKey(e => e.Id);
    }
}