using System.Collections.Generic;
using System.Threading.Tasks;

namespace RideSharing.Domain.Common
{
    public interface IDomainEventDispatcher
    {
        Task Dispatch(IDomainEvent domainEvent);
     
    }
}
