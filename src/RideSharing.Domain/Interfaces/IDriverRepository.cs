using System.Data;
using RideSharing.Domain.Entities;

namespace RideSharing.Domain.Interfaces;

public interface IDriverRepository
{
    Task<Driver?> GetByIdAsync(Guid id);
    Task AddAsync(Driver driver);
    Task UpdateAsync(Driver driver);
    Task<List<Driver>> GetAvailableDriversAsync();

   
    void Remove(Driver driver);
}
