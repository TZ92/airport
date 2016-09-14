using Data.Infrastructure;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    class EmployeeRepository :RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IDatabaseFactory dbFactory)
            : base(dbFactory)
        {

    }

        public int count()
        {
            throw new NotImplementedException();
        }
    }
    public interface IEmployeeRepository : IRepositoryBase<Employee>
    {
        int count();
    }
}
