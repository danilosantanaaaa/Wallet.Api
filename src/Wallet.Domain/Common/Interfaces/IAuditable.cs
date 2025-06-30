namespace Wallet.Domain.Common.Interfaces;

public interface IAuditable
{
    public DateTime CreateAt { get; }
    public DateTime? UpdateAt { get; }
    public Guid CreateByUserId { get; }
    public Guid? UpdateByUserId { get; }
}