using RideSharing.Domain.Entities;

namespace RideSharing.Domain.Interfaces;

public interface IRideRequestRepository
{
    Task AddAsync(RideRequest request);
    Task<RideRequest?> GetByIdAsync(Guid id);
    Task UpdateAsync(RideRequest request);
}
