using Wallet.Contracts.Cobrancas.Enums;
using Wallet.Domain.Carteiras;
using Wallet.Domain.Categorias;
using Wallet.Domain.Common.Entities;
using Wallet.Domain.Contatos;

namespace Wallet.Domain.Cobrancas;

public class Cobranca : AggregateRoot
{
    public string Descricao { get; private set; }
    public decimal Valor { get; private set; }
    public CobrancaStatus Status { get; private set; }

    public Guid CarteiraId { get; private set; }
    public Carteira Carteira { get; private set; } = default!;

    public Guid CategoriaId { get; private set; }
    public Categoria Categoria { get; private set; } = default!;

    public Guid ContatoId { get; private set; }
    public Contato Contato { get; private set; } = default!;

    public Cobranca(
        string descricao,
        decimal valor,
        CobrancaStatus status,
        Guid carteiraId,
        Guid categoriaId,
        Guid contatoId,
        Guid? id = null) : base(id ?? Guid.CreateVersion7())
    {
        Descricao = descricao;
        Valor = valor;
        Status = status;
        CarteiraId = carteiraId;
        CategoriaId = categoriaId;
        ContatoId = contatoId;
    }

    public void Update(
        string descricao,
        decimal valor,
        CobrancaStatus status,
        Guid carteiraId,
        Guid categoriaId,
        Guid contatoId)
    {
        Descricao = descricao;
        Valor = valor;
        Status = status;
        CarteiraId = carteiraId;
        CategoriaId = categoriaId;
        ContatoId = contatoId;
    }

    private Cobranca() : base(default)
    {
        // EF Core requires a parameterless constructor for entity instantiation
    }
}