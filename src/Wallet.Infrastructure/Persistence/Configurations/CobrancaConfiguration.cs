using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Wallet.Domain.Cobrancas;
using Wallet.Domain.Users;

namespace Wallet.Infrastructure.Persistence.Configurations;

internal sealed class CobrancaConfiguration : BaseConfiguration<Cobranca>
{
    public override void Configure(EntityTypeBuilder<Cobranca> builder)
    {
        base.Configure(builder);

        builder.HasOne(c => c.Carteira)
            .WithMany()
            .HasForeignKey(c => c.CarteiraId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(c => c.Categoria)
            .WithMany()
            .HasForeignKey(c => c.CategoriaId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(c => c.Contato)
            .WithMany()
            .HasForeignKey(c => c.ContatoId)
            .OnDelete(DeleteBehavior.Restrict);

        // builder.HasOne<User>()
        //     .WithMany()
        //     .HasForeignKey(c => c.UserId)
        //     .OnDelete(DeleteBehavior.Restrict);
    }
}