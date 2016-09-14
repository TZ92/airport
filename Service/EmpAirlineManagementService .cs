using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Infrastructure;
using Domain.Entities;
using Service.Pattern;

namespace Service
{
    public class EmpAirlineManagementService : Service<EmpAirline>, IEmpAirlineManagementService
    {

        IDatabaseFactory dbfactory = null;
        IUnitOfWork uow = null;
        private static DatabaseFactory dbFactory = new DatabaseFactory();
        private static IUnitOfWork utwk = new UnitOfWork(dbFactory);

        public EmpAirlineManagementService():base(utwk)
        {

        }
        
        

        public EmpAirline getEmpAirlineById(int id)
        {
            return utwk.EmpAirlineRepository.GetById(id);
        }

        public void AddEmpAirline(EmpAirline a)
        {
            utwk.EmpAirlineRepository.Add(a);
            utwk.Commit();
        }

        List<EmpAirline> IEmpAirlineManagementService.getAllEmpAirline()
        {
            return utwk.EmpAirlineRepository.GetAll().ToList();
        }

        List<EmpAirline> IEmpAirlineManagementService.getAllEmpAirlineByAirline(int id)
        {
            return utwk.EmpAirlineRepository.GetAll().Where(m => m.AirlinecompanyId == id).ToList();
        }
        public IEnumerable<EmpAirline> GetEmpAirlineByName(string title)
        {
            return utwk.EmpAirlineRepository.GetMany(t => t.Firstname.Contains(title) || t.Lastname.Contains(title));
        }
    }



public interface IEmpAirlineManagementService : IService<EmpAirline>
    {
        void AddEmpAirline(EmpAirline a);
        List<EmpAirline> getAllEmpAirline();
        EmpAirline getEmpAirlineById(int id);
        List<EmpAirline> getAllEmpAirlineByAirline(int id);
        IEnumerable<EmpAirline> GetEmpAirlineByName(string title);
    }

}
