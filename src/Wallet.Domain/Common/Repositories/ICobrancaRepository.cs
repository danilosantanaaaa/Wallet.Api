using Wallet.Contracts.Cobrancas;
using Wallet.Domain.Cobrancas;

namespace Wallet.Domain.Common.Repositories;

public interface ICobrancaRepository : IRepository<Cobranca>
{
    Task<CobrancaReportResponse> GetReportAsync();
}