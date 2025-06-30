using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Wallet.Domain.Users;

namespace Wallet.Infrastructure.Persistence.Configurations;

internal sealed class UserConfiguration : BaseConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);

        builder.HasIndex(u => u.Email)
            .IsUnique();
    }
}