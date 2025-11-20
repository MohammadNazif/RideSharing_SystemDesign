using RideSharing.Domain.Entities;

namespace RideSharing.Domain.Events;

public class RideRequestedEvent
{
    public RideRequest Ride { get; }

    public RideRequestedEvent(RideRequest ride)
    {
        Ride = ride;
    }
}
