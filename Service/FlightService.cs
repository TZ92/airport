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
    public class FlightService : Service<Flight> , IFlightService
    {
        private static DatabaseFactory dbFactory = new DatabaseFactory();
        private static IUnitOfWork utwk = new UnitOfWork(dbFactory);

        public FlightService():base(utwk)
        {

        }
       




    }

    public interface IFlightService : IService<Flight>
    {

    }


}
