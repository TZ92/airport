using Data.Infrastructure;
using Data.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class AirlineRepository : RepositoryBase<Airlinecompany>, IAirlineRepository
    {
        public AirlineRepository(IDatabaseFactory dbFactory)
			: base(dbFactory)
		{

		}
    }
    public interface IAirlineRepository : IRepositoryBase<Airlinecompany> { }
}
