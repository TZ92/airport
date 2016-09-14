using Data.Infrastructure;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class FlightRepository : RepositoryBase<Flight>, IFlightRepository
    {
        public FlightRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {


        }
    }
    public interface IFlightRepository : IRepositoryBase<Flight>
    {

    }
}
