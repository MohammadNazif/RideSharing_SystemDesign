using RideSharing.Domain.Common;
using RideSharing.Domain.Interfaces;
using RideSharing.Infrastructure.Data;

namespace RideSharing.Infrastructure.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    public IDriverRepository Drivers { get; }
    public UnitOfWork(ApplicationDbContext context,IDriverRepository drivers)
    {
        _context = context;
        Drivers = drivers;
    }


    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }
}
