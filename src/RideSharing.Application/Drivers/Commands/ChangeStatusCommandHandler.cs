using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RideSharing.Domain.Common;
using RideSharing.Domain.Entities;
using RideSharing.Domain.Interfaces;

namespace RideSharing.Application.Drivers.Commands
{
    public class ChangeStatusCommandHandler : IRequestHandler<ChangeStatus, bool>
    {
        private readonly IDriverRepository _driver;
        private readonly IUnitOfWork _uow;
        public ChangeStatusCommandHandler(IDriverRepository driver,IUnitOfWork uow)
        {
            _driver = driver;
            _uow = uow;
        }
        async  Task<bool> IRequestHandler<ChangeStatus, bool>.Handle(ChangeStatus request, CancellationToken cancellationToken)
        {
            var driver = await _driver.GetByIdAsync(request.DriverId);

            if (driver == null)
                return false;

            driver.ChangeStatus(request.NewStatus);

            await _driver.UpdateAsync(driver);
            await _uow.SaveChangesAsync();

            return true;
        }
    }
}
