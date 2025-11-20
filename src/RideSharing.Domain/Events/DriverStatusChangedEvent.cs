using RideSharing.Domain.Common;
using RideSharing.Domain.Enums;

namespace RideSharing.Domain.Events;

public record DriverStatusChangedEvent(Guid DriverId, DriverStatus Status)
    : IDomainEvent;
