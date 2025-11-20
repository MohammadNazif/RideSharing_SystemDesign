using RideSharing.Domain.Entities;

namespace RideSharing.Domain.Interfaces;

public interface IDriverRepository
{
    Task<Driver?> GetAvailableDriverAsync();
    Task AddAsync(Driver driver);
}
