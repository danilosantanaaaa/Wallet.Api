using Wallet.Contracts.Categorias.Enums;

namespace Wallet.Contracts.Categorias;

public record CategoriaRequest(
    string Nome,
    string? Descricao,
    CategoriaTipo Tipo);