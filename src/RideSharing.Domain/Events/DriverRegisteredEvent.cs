using RideSharing.Domain.Common;

namespace RideSharing.Domain.Events;

public record DriverRegisteredEvent(Guid DriverId) : IDomainEvent;
