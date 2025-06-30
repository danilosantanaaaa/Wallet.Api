namespace Wallet.Contracts.Contatos;

public record ContatoResponse(
    Guid Id,
    string Nome,
    string? Email,
    string? Telefone);