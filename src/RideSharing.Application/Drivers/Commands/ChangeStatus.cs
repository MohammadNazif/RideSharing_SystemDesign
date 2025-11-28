
using MediatR;
using RideSharing.Domain.Entities;
using RideSharing.Domain.Enums;


namespace RideSharing.Application.Drivers.Commands
{
    public class ChangeStatus : IRequest<bool>
    {
        public Guid DriverId { get; set; }
        public DriverStatus NewStatus { get; set; }
    }

}
