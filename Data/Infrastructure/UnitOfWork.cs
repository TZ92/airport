
using Data.Models;
using Data.Models.Repositories;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {

        private Context dataContext;

        IDatabaseFactory dbFactory;
        public UnitOfWork(IDatabaseFactory dbFactory)
        {
            this.dbFactory = dbFactory;
            dataContext = dbFactory.DataContext;
        }

        

        public void Commit()
        {
            dataContext.SaveChanges();
        }
        public void CommitAsync()
        {
            dataContext.SaveChangesAsync();
        }
        public void Dispose()
        {
            dataContext.Dispose();
        }
        public IRepositoryBaseAsync<T> getRepository<T>() where T : class
        {
            IRepositoryBaseAsync<T> repo = new RepositoryBase<T>(dbFactory);
            return repo;
        }

        private IFlightRepository flightRepository;
        public IFlightRepository FlightRepository
        {
            get { return flightRepository = new FlightRepository(dbFactory); }
        }


        private IPlaneRepository planeRepository;
        public IPlaneRepository PlaneRepository
        {
            get { return planeRepository = new PlaneRepository(dbFactory); }
        }

        private IReservationRepository reservationRepository;
        public IReservationRepository ReservationRepository
        {
            get
            {
                return reservationRepository = new ReservationRepository(dbFactory);
            }
        }


        private IAirlineRepository airlineRepository;
        public IAirlineRepository AirlineRepository
        {
            get { return airlineRepository = new AirlineRepository(dbFactory); }
        }

        private IEmpAirlineRepository empAirlineRepository;
        public IEmpAirlineRepository EmpAirlineRepository
        {
            get { return empAirlineRepository = new EmpAirlineRepository(dbFactory); }
        }
        private IDealRepository dealRepository;


        public IDealRepository DealRepository
        {
            get { return dealRepository = new DealRepository(dbFactory); }
        }


        private IEmployeeRepository employeeRepository;


        public IEmployeeRepository EmployeeRepository
        {
            get { return employeeRepository = new EmployeeRepository(dbFactory); }
        }



        /*
private IDirectionRepository directionRepository;
public IDirectionRepository DirectionRepository
{
   get { return directionRepository = new DirectionRepository(dbFactory); ; }
}

private IShareRepository shareRepository;
public IShareRepository ShareRepository
{
   get
   {
       return shareRepository = new ShareRepository(dbFactory); ;
   }
}



private IBrokerRepository brokerRepository;
public IBrokerRepository BrokerRepository
{
   get
   {
   return brokerRepository = new BrokerRepository(dbFactory); ;
   }
}*/
    }
}
