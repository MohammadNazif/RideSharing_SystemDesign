using RideSharing.Domain.ValueObjects;
using RideSharing.Domain.Enums;
using RideSharing.Domain.Common;
using RideSharing.Domain.Events;

namespace RideSharing.Domain.Entities;

public class Driver
{
    private readonly List<IDomainEvent> _events = new();
    public IReadOnlyList<IDomainEvent> Events => _events.AsReadOnly();

    private void AddEvent(IDomainEvent domainEvent)
    {
        _events.Add(domainEvent);
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string PhoneNumber { get; private set; }

    public DriverStatus Status { get; private set; }
    public DriverLocation Location { get; private set; }

    private Driver() { } // EF ke liye

    public Driver(string name, string phone)
    {
        Id = Guid.NewGuid();
        Name = name;
        PhoneNumber = phone;
        Status = DriverStatus.Offline;

        // 🔥 Event Raised
        AddEvent(new DriverRegisteredEvent(Id));
    }

    public void UpdateLocation(double lat, double lng)
    {
        Location = new DriverLocation(lat, lng);

        // 🔥 Event Raised
        AddEvent(new DriverLocationUpdatedEvent(Id, Location));
    }

    public void ChangeStatus(DriverStatus status)
    {
        Status = status;

        // 🔥 Event Raised
        AddEvent(new DriverStatusChangedEvent(Id, status));
    }
}
