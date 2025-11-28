
using RideSharing.Domain.Enums;
using RideSharing.Domain.Common;
using RideSharing.Domain.Events;

namespace RideSharing.Domain.Entities;

public class Driver : BaseEntity
{
   

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

        // FIX HERE
        Location = new DriverLocation(Id, 0, 0);  // default lat/lng

        AddDomainEvent(new DriverRegisteredEvent(Id));
    }

    public void UpdateLocation(double lat, double lng)
    {

        Location.Latitude = lat;
        Location.Longitude = lng;

        AddDomainEvent(new DriverLocationUpdatedEvent(Id, Location));
    }


    public void ChangeStatus(DriverStatus status)
    {
        Status = status;

        AddDomainEvent(new DriverStatusChangedEvent(Id, status));
    }
}
