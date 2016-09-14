using Data.Infrastructure;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models.Repositories
{
    class DealRepository : RepositoryBase<Deal>, IDealRepository
    {
        public DealRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {

        }
    }
    public interface IDealRepository : IRepositoryBase<Deal>
    {

    }
}


