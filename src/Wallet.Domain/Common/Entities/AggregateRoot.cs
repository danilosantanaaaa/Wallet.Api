using Wallet.Domain.Common.Interfaces;

namespace Wallet.Domain.Common.Entities;

public abstract class AggregateRoot : Entity, IAuditable
{
    protected AggregateRoot(Guid id) : base(id)
    { }

    public DateTime CreateAt { get; private set; }

    public DateTime? UpdateAt { get; private set; }

    public Guid CreateByUserId { get; private set; }

    public Guid? UpdateByUserId { get; private set; }
}