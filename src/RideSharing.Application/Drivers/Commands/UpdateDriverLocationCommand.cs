using MediatR;

namespace RideSharing.Application.Drivers.Commands.UpdateLocation
{
    public class UpdateDriverLocationCommand : IRequest<bool>
    {
        public Guid DriverId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
