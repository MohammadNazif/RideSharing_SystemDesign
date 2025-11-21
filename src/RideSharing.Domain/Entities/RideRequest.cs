namespace RideSharing.Domain.Entities;

public class RideRequest
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Pickup { get; set; }
    public string Destination { get; set; }
    public string Status { get; set; } // Pending, Accepted, Completed, Cancelled
}
