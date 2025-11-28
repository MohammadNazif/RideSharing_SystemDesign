using MediatR;
using RideSharing.Domain.Common;

namespace RideSharing.Infrastructure.Events
{
    public class DomainEventDispatcher : IDomainEventDispatcher
    {
        private readonly IMediator _mediator;

        public DomainEventDispatcher(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Dispatch(IDomainEvent domainEvent)
        {
            await _mediator.Publish(domainEvent);
        }

       
    }
}
