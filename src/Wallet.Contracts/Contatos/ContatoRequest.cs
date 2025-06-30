namespace Wallet.Contracts.Contatos;

public record ContatoRequest(
    string Nome,
    string? Email,
    string? Telefone);