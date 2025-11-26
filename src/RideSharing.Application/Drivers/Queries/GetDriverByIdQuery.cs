using MediatR;
using RideSharing.Domain.Entities;

namespace RideSharing.Application.Drivers.Queries.GetDriverById
{
    public class GetDriverByIdQuery : IRequest<Driver?>
    {
        public Guid Id { get; set; }
        public GetDriverByIdQuery(Guid id) => Id = id;
    }
}
