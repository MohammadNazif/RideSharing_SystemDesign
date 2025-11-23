using MediatR;

namespace RideSharing.Application.Drivers.Commands.CreateDriver
{
    public class CreateDriverCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }
}
