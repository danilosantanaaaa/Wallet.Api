using FriendlyResult;
using FriendlyResult.Enums;

namespace Wallet.Application.Services.Interfaces;

public interface IService<TRequest>
{
    Task<Result<Guid>> CreateAsync(TRequest request);
    Task<Result<Updated>> UpdateAsync(Guid id, TRequest request);
    Task<Result<Deleted>> DeleteAsync(Guid id);
}