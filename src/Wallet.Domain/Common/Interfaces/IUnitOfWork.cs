namespace Wallet.Domain.Common.Interfaces;

public interface IUnitOfWork
{
    /// <summary>
    /// Saves all changes made in this unit of work to the database.
    /// </summary>
    /// <returns>The number of state entries written to the database.</returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Disposes the unit of work, releasing any resources it holds.
    /// </summary>
    void Dispose();
}