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
    public class PlaneService : Service<Plane> , IPlaneService
    {
        private static DatabaseFactory dbFactory = new DatabaseFactory();
        private static IUnitOfWork utwk = new UnitOfWork(dbFactory);

        public PlaneService():base(utwk)
        {

        }
        public void AddPlane(Plane a)
        {
            utwk.PlaneRepository.Add(a);
            utwk.Commit();
        }

        public List<Plane> getAllPlane()
        {
            return utwk.PlaneRepository.GetAll().ToList();
        }

        public Plane getPlaneById(int id)
        {
            return utwk.PlaneRepository.GetById(id);
        }

        public void updatePlane(Plane p)
        {

            utwk.PlaneRepository.Update(p);
            utwk.Commit();
        }



    }

    public interface IPlaneService : IService<Plane>
    {
        void AddPlane(Plane a);
        List<Plane> getAllPlane();
        Plane getPlaneById(int id);

        void updatePlane(Plane p);
    }


}
