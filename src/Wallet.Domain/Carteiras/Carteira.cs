
using Wallet.Domain.Common.Entities;

namespace Wallet.Domain.Carteiras;

public class Carteira : AggregateRoot
{
    public string Nome { get; private set; }
    public string? Descricao { get; private set; }
    public bool Status { get; private set; }

    public Carteira(
        string nome,
        string? descricao,
        Guid? id = null) : base(id ?? Guid.CreateVersion7())
    {
        Nome = nome;
        Descricao = descricao;
        Status = true;
    }

    public void Update(
        string nome,
        string? descricao)
    {
        Nome = nome;
        Descricao = descricao;
    }

    private Carteira() : base(Guid.Empty)
    { }
}