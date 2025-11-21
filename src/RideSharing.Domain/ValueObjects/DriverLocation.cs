using RideSharing.Domain.Entities;

public class DriverLocation
{
    public Guid Id { get; set; }
    public Guid DriverId { get; set; }

    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public Driver Driver { get; set; }
}
