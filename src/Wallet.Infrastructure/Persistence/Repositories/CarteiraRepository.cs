using Wallet.Domain.Carteiras;
using Wallet.Domain.Common.Repositories;
using Wallet.Infrastructure.Persistence.Contexts;

namespace Wallet.Infrastructure.Persistence.Repositories;

internal sealed class CarteiraRepository(ApiDbContext context) : Repository<Carteira>(context), ICarteiraRepository;