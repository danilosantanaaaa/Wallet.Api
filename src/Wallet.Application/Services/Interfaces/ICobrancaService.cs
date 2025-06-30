using FriendlyResult;

using Wallet.Contracts.Cobrancas;

namespace Wallet.Application.Services.Interfaces;

public interface ICobrancaService : IService<CobrancaRequest>
{
    Task<Result<CobrancaResponse?>> GetByIdAsync(Guid id);
    Task<IEnumerable<CobrancaResponse>> GetAllAsync();
    Task<CobrancaReportResponse> GetReportAsync();
}