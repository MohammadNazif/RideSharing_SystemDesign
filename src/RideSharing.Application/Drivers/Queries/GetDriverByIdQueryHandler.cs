using MediatR;
using RideSharing.Domain.Entities;
using RideSharing.Domain.Interfaces;

namespace RideSharing.Application.Drivers.Queries.GetDriverById
{
    public class GetDriverByIdQueryHandler
        : IRequestHandler<GetDriverByIdQuery, Driver?>
    {
        private readonly IDriverRepository _repo;

        public GetDriverByIdQueryHandler(IDriverRepository repo)
        {
            _repo = repo;
        }

        public async Task<Driver?> Handle(GetDriverByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetByIdAsync(request.Id);
        }
    }
}
