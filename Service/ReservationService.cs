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
    public class ReservationService : Service<Reservation>, IReservationService
    {
        private static DatabaseFactory dbFactory = new DatabaseFactory();
        private static IUnitOfWork utwk = new UnitOfWork(dbFactory);

        public ReservationService() : base(utwk)
        {

        }
        public void AddReservation(Reservation r)
        {
            utwk.ReservationRepository.Add(r);
            utwk.Commit();
        }

        public List<Reservation> getAllReservation()
        {
            return utwk.ReservationRepository.GetAll().ToList();
        }

        public Reservation getReservationById(int id)
        {
            return utwk.ReservationRepository.GetById(id);
        }
    }


}

public interface IReservationService : IService<Reservation>
{
    void AddReservation(Reservation r);
    List<Reservation> getAllReservation();
    Reservation getReservationById(int id);
}


