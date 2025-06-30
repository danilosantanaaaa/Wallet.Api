using FriendlyResult;

using Wallet.Contracts.Carteiras;

namespace Wallet.Application.Services.Interfaces;

public interface ICarteiraService : IService<CarteiraRequest>
{
    Task<Result<CarteiraResponse?>> GetByIdAsync(Guid id);
    Task<IEnumerable<CarteiraResponse>> GetAllAsync();
}