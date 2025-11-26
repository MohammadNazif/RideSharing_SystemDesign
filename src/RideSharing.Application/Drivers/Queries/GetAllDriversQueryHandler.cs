using MediatR;
using RideSharing.Domain.Entities;
using RideSharing.Domain.Interfaces;

namespace RideSharing.Application.Drivers.Queries.GetAllDrivers
{
    public class GetAllDriversQueryHandler
        : IRequestHandler<GetDriverQuery, List<Driver>>
    {
        private readonly IDriverRepository _driverRepo;

        public GetAllDriversQueryHandler(IDriverRepository driverRepo)
        {
            _driverRepo = driverRepo;
        }

        public async Task<List<Driver>> Handle(GetDriverQuery request, CancellationToken cancellationToken)
        {
            return await _driverRepo.GetAvailableDriversAsync();

        }
    }
}
