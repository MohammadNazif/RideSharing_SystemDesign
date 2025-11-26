using MediatR;
using RideSharing.Domain.Common;
using RideSharing.Domain.Interfaces;

namespace RideSharing.Application.Drivers.Commands.UpdateLocation
{
    public class UpdateDriverLocationCommandHandler
        : IRequestHandler<UpdateDriverLocationCommand, bool>
    {
        private readonly IDriverRepository _repo;
        private readonly IUnitOfWork _uow;

        public UpdateDriverLocationCommandHandler(IDriverRepository repo, IUnitOfWork uow)
        {
            _repo = repo;
            _uow = uow;
        }

        public async Task<bool> Handle(UpdateDriverLocationCommand request, CancellationToken cancellationToken)
        {
            var driver = await _repo.GetByIdAsync(request.DriverId);

            if (driver == null)
                return false;

            driver.UpdateLocation(request.Latitude, request.Longitude);

            await _repo.UpdateAsync(driver);
            await _uow.SaveChangesAsync();

            return true;
        }
    }
}
