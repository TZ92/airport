using Data.Infrastructure;
using Domain.Entities;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class EmployeeService : Service<Employee>, IEmployeeService
    {
        private static DatabaseFactory dbFactory = new DatabaseFactory();
        private static IUnitOfWork utwk = new UnitOfWork(dbFactory);

        public EmployeeService() : base(utwk)
        {

        }
        public void AddEmployee(Employee e)
        {
            utwk.EmployeeRepository.Add(e);
            utwk.Commit();
        }

        public List<Employee> getAllEmployee()
        {
            return utwk.EmployeeRepository.GetAll().ToList();
        }

        public Employee getEmployeeById(int id)
        {
            return utwk.EmployeeRepository.GetById(id);
        }

        public int countEmployee()
        {

            return utwk.EmployeeRepository.count();
        }
            
    }

    public interface IEmployeeService : IService<Employee>
    {
        void AddEmployee(Employee e);
        List<Employee> getAllEmployee();
        Employee getEmployeeById(int id);

        int countEmployee();
    }
}



 
