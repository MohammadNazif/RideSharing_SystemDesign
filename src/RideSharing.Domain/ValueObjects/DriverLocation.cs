namespace RideSharing.Domain.ValueObjects;

public class DriverLocation
{
    public double Latitude { get; private set; }
    public double Longitude { get; private set; }

    private DriverLocation() { }

    public DriverLocation(double lat, double lng)
    {
        Latitude = lat;
        Longitude = lng;
    }
}
