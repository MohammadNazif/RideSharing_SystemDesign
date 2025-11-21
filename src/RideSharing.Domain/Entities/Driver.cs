
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

    // ❗ THIS MUST BE NULLABLE
    public DriverLocation? Location { get; private set; }

    private Driver() { } // EF ke liye

    public Driver(string name, string phone)
    {
        Id = Guid.NewGuid();
        Name = name;
        PhoneNumber = phone;
        Status = DriverStatus.Offline;

        AddEvent(new DriverRegisteredEvent(Id));
    }

    public void UpdateLocation(double lat, double lng)
    {
        

        AddEvent(new DriverLocationUpdatedEvent(Id, Location));
    }

    public void ChangeStatus(DriverStatus status)
    {
        Status = status;

        AddEvent(new DriverStatusChangedEvent(Id, status));
    }
}
