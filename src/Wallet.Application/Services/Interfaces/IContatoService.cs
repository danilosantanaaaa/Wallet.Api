using FriendlyResult;

using Wallet.Contracts.Contatos;

namespace Wallet.Application.Services.Interfaces;

public interface IContatoService : IService<ContatoRequest>
{
    Task<Result<ContatoResponse?>> GetByIdAsync(Guid id);
    Task<IEnumerable<ContatoResponse>> GetAllAsync();
}