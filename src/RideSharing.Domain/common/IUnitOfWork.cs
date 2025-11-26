using RideSharing.Domain.Interfaces;

namespace RideSharing.Domain.Common;

public interface IUnitOfWork
{

    IDriverRepository Drivers { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
