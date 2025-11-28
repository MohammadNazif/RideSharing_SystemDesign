using MediatR;
using Microsoft.Extensions.Logging;
using RideSharing.Domain.Events;

public class DriverLocationUpdatedEventHandler
    : INotificationHandler<DriverLocationUpdatedEvent>
{
    private readonly ILogger<DriverLocationUpdatedEventHandler> _logger;

    public DriverLocationUpdatedEventHandler(
        ILogger<DriverLocationUpdatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(DriverLocationUpdatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation(
            "Driver Location Updated: {DriverId} -> {Lat}, {Lng}",
            notification.DriverId,
            notification.Location.Latitude,
            notification.Location.Longitude
        );

        return Task.CompletedTask;
    }
}
