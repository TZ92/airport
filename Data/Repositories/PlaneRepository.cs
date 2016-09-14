using Data.Infrastructure;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class PlaneRepository : RepositoryBase<Plane>, IPlaneRepository
    {
        public PlaneRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {



        }
    }
    public interface IPlaneRepository : IRepositoryBase<Plane>
    {

    }
}
