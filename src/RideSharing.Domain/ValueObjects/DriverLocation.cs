using System.Text.Json.Serialization;
using RideSharing.Domain.Entities;


public class DriverLocation

{

    public DriverLocation(Guid driverId, double latitude, double longitude)
    {
        DriverId = driverId;
        Latitude = latitude;
        Longitude = longitude;
    }
    public Guid Id { get; set; }
    public Guid DriverId { get; set; }

    public double Latitude { get; set; }
    public double Longitude { get; set; }

    [JsonIgnore]
    public Driver Driver { get; set; }
}
