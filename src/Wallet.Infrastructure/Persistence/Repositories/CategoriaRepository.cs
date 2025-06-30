using Wallet.Domain.Categorias;
using Wallet.Domain.Common.Repositories;
using Wallet.Infrastructure.Persistence.Contexts;

namespace Wallet.Infrastructure.Persistence.Repositories;

internal sealed class CategoriaRepository(ApiDbContext context) : Repository<Categoria>(context), ICategoriaRepository;