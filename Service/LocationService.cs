using Data.Infrastructure;
using Data.Models;
using Domain.Entities;
using Service.Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class LocationService : Service<Location> , ILocationService
    {


        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);
        public LocationService() : base(ut)
        {

        }
        public void add(Location loc)
        {
            ut.getRepository<Location>().Add(loc);
        }
        public Location GetByIdLocation(int id)
        {
            return ut.getRepository<Location>().GetById(id);

        }
        public void update(Location loc)
        {
            ut.getRepository<Location>().Update(loc);
        }
        public void delete(Location loc)
        {
            ut.getRepository<Location>().Delete(loc);
        }
        public Task<List<Location>> GetAll()
        {
            return ut.getRepository<Location>().GetAllAsync();

        }

    }
}
