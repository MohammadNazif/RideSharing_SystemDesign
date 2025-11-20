using RideSharing.Domain.Common;
using RideSharing.Domain.ValueObjects;

namespace RideSharing.Domain.Events;

public record DriverLocationUpdatedEvent(Guid DriverId, DriverLocation Location)
    : IDomainEvent;
