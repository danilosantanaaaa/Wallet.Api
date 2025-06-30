namespace Wallet.Contracts.Carteiras;

public record CarteiraRequest(
    string Nome,
    string? Descricao);