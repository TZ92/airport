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
    public class AirlineManagementService : Service<Airlinecompany>, IAirlineManagementService
    {

        IDatabaseFactory dbfactory = null;
        IUnitOfWork uow = null;
        private static DatabaseFactory dbFactory = new DatabaseFactory();
        private static IUnitOfWork utwk = new UnitOfWork(dbFactory);

        public AirlineManagementService():base(utwk)
        {

        }
        
        

        public Airlinecompany getAirlineById(int id)
        {
            return utwk.AirlineRepository.GetById(id);
        }

        public void AddAirline(Airlinecompany a)
        {
            utwk.AirlineRepository.Add(a);
            utwk.Commit();
        }

        List<Airlinecompany> IAirlineManagementService.getAllAirline()
        {
            return utwk.AirlineRepository.GetAll().ToList();
        }
         

        List<EmpAirline> IAirlineManagementService.EmployesByAirline(int id)
        {
            return utwk.AirlineRepository.GetById(id).EmpAirlines.ToList();
        }
        public IEnumerable<Airlinecompany> GetAirlineByName(string title)
        {
            return utwk.AirlineRepository.GetMany(t => t.Name.Contains(title));
        }
    }



public interface IAirlineManagementService : IService<Airlinecompany>
    {
        void AddAirline(Airlinecompany a);
        List<Airlinecompany> getAllAirline();
        Airlinecompany getAirlineById(int id);
        List<EmpAirline> EmployesByAirline(int id);
        IEnumerable<Airlinecompany> GetAirlineByName(string title);
    }

}
