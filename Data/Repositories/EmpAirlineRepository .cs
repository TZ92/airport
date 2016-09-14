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
    public class EmpAirlineRepository : RepositoryBase<EmpAirline>, IEmpAirlineRepository
    {
        public EmpAirlineRepository(IDatabaseFactory dbFactory)
			: base(dbFactory)
		{

		}
    }
    public interface IEmpAirlineRepository : IRepositoryBase<EmpAirline> { }
}
