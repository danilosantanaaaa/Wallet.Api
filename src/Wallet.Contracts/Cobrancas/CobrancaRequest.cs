using Wallet.Contracts.Cobrancas.Enums;

namespace Wallet.Contracts.Cobrancas;

public record CobrancaRequest(
    string Descricao,
    decimal Valor,
    CobrancaStatus Status,
    Guid CarteiraId,
    Guid CategoriaId,
    Guid ContatoId);