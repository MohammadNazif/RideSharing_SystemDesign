using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RideSharing.Domain.Entities;
using RideSharing.Domain.Interfaces;

namespace RideSharing.Infrastructure.Data.Repositories
{
    internal class DriverRepo : IDriverRepository
    {
        private readonly ApplicationDbContext _context;
        public DriverRepo(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Driver?> GetByIdAsync(Guid id)
        {
            return await _context.Drivers
                .Include(d => d.Location)
                .FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task AddAsync(Driver driver)
        {
            await _context.Drivers.AddAsync(driver);
        }

        
        public void Remove(Driver driver)
        {
            _context.Drivers.Remove(driver);
        }

        // 🔥 Custom query: available drivers only
        public async Task<List<Driver>> GetAvailableDriversAsync()
        {
            return await _context.Drivers
                .Include(d => d.Location)
                .Where(d => d.Status == Domain.Enums.DriverStatus.Available)
                .ToListAsync();
        }

        public async Task UpdateAsync(Driver driver)
        {
             _context.Drivers.Update(driver);
        }
    }
}
