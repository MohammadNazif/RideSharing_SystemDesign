using MediatR;
using RideSharing.Domain.Common;
using RideSharing.Domain.Entities;
using RideSharing.Domain.Interfaces;

namespace RideSharing.Application.Drivers.Commands.CreateDriver
{
    public class CreateDriverCommandHandler
        : IRequestHandler<CreateDriverCommand, Guid>
    {
        private readonly IDriverRepository _repo;
        private readonly IUnitOfWork _uow;

        public CreateDriverCommandHandler(IDriverRepository repo, IUnitOfWork uow)
        {
            _repo = repo;
            _uow = uow;
        }

        public async Task<Guid> Handle(CreateDriverCommand request, CancellationToken cancellationToken)
        {
            var driver = new Driver(request.Name, request.PhoneNumber);

            await _repo.AddAsync(driver);
            await _uow.SaveChangesAsync();

            return driver.Id;
        }
    }
}
