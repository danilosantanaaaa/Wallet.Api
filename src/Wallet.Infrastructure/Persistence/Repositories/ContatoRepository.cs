using Wallet.Domain.Common.Repositories;
using Wallet.Domain.Contatos;
using Wallet.Infrastructure.Persistence.Contexts;

namespace Wallet.Infrastructure.Persistence.Repositories;

internal sealed class ContatoRepository(ApiDbContext context) : Repository<Contato>(context), IContatoRepository
{ }