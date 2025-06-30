using FriendlyResult;

using Wallet.Contracts.Categorias;

namespace Wallet.Application.Services.Interfaces;

public interface ICategoriaService : IService<CategoriaRequest>
{
    Task<Result<CategoriaResponse?>> GetByIdAsync(Guid id);
    Task<IEnumerable<CategoriaResponse>> GetAllAsync();
}