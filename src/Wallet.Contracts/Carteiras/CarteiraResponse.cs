namespace Wallet.Contracts.Carteiras;

public record CarteiraResponse(
    Guid Id,
    string Nome,
    string? Descricao);