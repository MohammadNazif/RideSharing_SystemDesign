using RideSharing.Domain.Common;
using RideSharing.Domain.Interfaces;
using RideSharing.Infrastructure.Data;

namespace RideSharing.Infrastructure.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;

    private readonly IDomainEventDispatcher _dispatcher;
    public IDriverRepository Drivers { get; }
    public UnitOfWork(ApplicationDbContext context,IDriverRepository drivers, IDomainEventDispatcher dispatcher)
    {
        _context = context;
        Drivers = drivers;
        _dispatcher = dispatcher;
    }


    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entities = _context.ChangeTracker
            .Entries<BaseEntity>()
            .Where(e => e.Entity.DomainEvents.Any())
            .ToList();

        var domainEvents = entities
            .SelectMany(e => e.Entity.DomainEvents)
            .ToList();

        var result = await _context.SaveChangesAsync(cancellationToken);

        foreach (var domainEvent in domainEvents)
        {
            await _dispatcher.Dispatch(domainEvent); 
        }

        foreach (var entity in entities)
        {
            entity.Entity.ClearDomainEvents();
        }

        return result;
    }
}


