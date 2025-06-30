using Microsoft.EntityFrameworkCore;

using Wallet.Contracts.Categorias.Enums;
using Wallet.Contracts.Cobrancas;
using Wallet.Domain.Cobrancas;
using Wallet.Domain.Common.Repositories;
using Wallet.Infrastructure.Persistence.Contexts;

namespace Wallet.Infrastructure.Persistence.Repositories;

internal sealed class CobrancaRepository(ApiDbContext context) : Repository<Cobranca>(context), ICobrancaRepository
{
    public async Task<CobrancaReportResponse> GetReportAsync()
    {
        var query = _context.Set<Cobranca>()
            .Include(c => c.Categoria);

        var cobrancas_by_tipo =
            await query
            .GroupBy(c => c.Categoria.Tipo)
            .Select(c => new CobrancaByTipo(
                c.Key,
                c.Sum(y => y.Valor)))
            .ToArrayAsync();

        // Agrupando por entrada e saida
        var cobrancas_group =
            await query
            .GroupBy(c => new { c.Categoria.Nome, c.Categoria.Tipo })
            .Select(c => new CobrancaGroup(
                c.Key.Nome,
                c.Key.Tipo,
                c.Sum(x => x.Valor)))
            .ToListAsync();

        return new CobrancaReportResponse(cobrancas_by_tipo, cobrancas_group);
    }
}