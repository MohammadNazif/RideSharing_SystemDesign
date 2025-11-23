using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using RideSharing.Domain.Entities;

namespace RideSharing.Application.Drivers.Queries
{
    public  class GetDriverQuery : IRequest<List<Driver>>
    {
        public GetDriverQuery()
        {
        }
    }
}
