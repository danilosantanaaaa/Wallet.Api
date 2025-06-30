using Wallet.Contracts.Categorias.Enums;

namespace Wallet.Contracts.Cobrancas;

public record CobrancaReportResponse(
    CobrancaByTipo[] CobrancaByTipo,
    List<CobrancaGroup> CobrancaGroups);

public record CobrancaByTipo(
    CategoriaTipo Tipo,
    decimal Total);

public record CobrancaGroup(
    string CategoriaName,
    CategoriaTipo Tipo,
    decimal Valor_Total);