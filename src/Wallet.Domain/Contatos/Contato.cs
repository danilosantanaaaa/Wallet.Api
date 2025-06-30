using Wallet.Domain.Common.Entities;

namespace Wallet.Domain.Contatos;

public class Contato : AggregateRoot
{
    public string Nome { get; private set; }
    public string? Email { get; private set; }
    public string? Telefone { get; private set; }
    public bool Status { get; private set; }

    public Contato(
        string nome,
        string? email,
        string? telefone,
        Guid? id = null) : base(id ?? Guid.CreateVersion7())
    {
        Nome = nome;
        Email = email;
        Telefone = telefone;
        Status = true;
    }

    public void Update(
        string nome,
        string? email,
        string? telefone)
    {
        Nome = nome;
        Email = email;
        Telefone = telefone;
    }

    // Usado pelo EF Core
    private Contato() : base(Guid.Empty)
    { }
}
