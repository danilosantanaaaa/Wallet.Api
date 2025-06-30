using Wallet.Contracts.Categorias.Enums;

namespace Wallet.Contracts.Categorias;

public record CategoriaResponse(
    Guid Id,
    string Nome,
    string? Descricao,
    CategoriaTipo Tipo);