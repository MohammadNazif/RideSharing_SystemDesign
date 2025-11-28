using MediatR;
using RideSharing.Domain.Events;

namespace RideSharing.Application.Drivers.Events
{
    public class DriverLocationUpdatedEventHandler
        : INotificationHandler<DriverLocationUpdatedEvent>
    {
        public Task Handle(DriverLocationUpdatedEvent notification, CancellationToken cancellationToken)
        {
            Console.WriteLine(
                $"Driver Location Updated: {notification.DriverId} -> " +
                $"{notification.Location.Latitude}, {notification.Location.Longitude}"
            );

            return Task.CompletedTask;
        }
    }
}
