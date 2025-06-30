
using Wallet.Contracts.Categorias.Enums;
using Wallet.Domain.Common.Entities;

namespace Wallet.Domain.Categorias;

public class Categoria : AggregateRoot
{
    public string Nome { get; private set; }
    public string? Descricao { get; private set; }
    public bool Status { get; private set; }
    public CategoriaTipo Tipo { get; private set; }

    public Categoria(
        string nome,
        string? descricao,
        CategoriaTipo tipo,
        Guid? id = null) : base(id ?? Guid.CreateVersion7())
    {
        Nome = nome;
        Descricao = descricao;
        Tipo = tipo;
        Status = true;
    }

    public void Update(
        string nome,
        string? descricao,
        CategoriaTipo tipo)
    {
        Nome = nome;
        Descricao = descricao;
        Tipo = tipo;
    }

    private Categoria() : base(default)
    { }
}
