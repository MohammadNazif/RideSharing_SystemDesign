using RideSharing.Domain.Common;


namespace RideSharing.Domain.Events;

public record DriverLocationUpdatedEvent(Guid DriverId, DriverLocation Location)
    : IDomainEvent;
