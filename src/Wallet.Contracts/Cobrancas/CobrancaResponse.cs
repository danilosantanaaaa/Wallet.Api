using Wallet.Contracts.Cobrancas.Enums;

namespace Wallet.Contracts.Cobrancas;

public record CobrancaResponse(
    Guid Id,
    string Descricao,
    decimal Valor,
    CobrancaStatus Status,
    Guid CarteiraId,
    Guid CategoriaId,
    Guid ContatoId);