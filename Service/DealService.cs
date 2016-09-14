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
   public class DealService : Service<Deal>, IDealService
    {
        private static DatabaseFactory dbFactory = new DatabaseFactory();
    private static IUnitOfWork utwk = new UnitOfWork(dbFactory);

    public DealService():base(utwk)
        {

    }
    public void AddDeal(Deal a)
    {
        utwk.DealRepository.Add(a);
        utwk.Commit();
    }

    public List<Deal> getAllDeal()
    {
        return utwk.DealRepository.GetAll().ToList();
    }

    public Deal getDealById(int id)
    {
        return utwk.DealRepository.GetById(id);
    }

    public void updateDeal(Deal d)
    {

        utwk.DealRepository.Update(d);
        utwk.Commit();
    }

        public IEnumerable<Flight> GetAllFlight()
        {
            return utwk.FlightRepository.GetAll();
        }




    }

public interface IDealService : IService<Deal>
{
    void AddDeal(Deal a);
    List<Deal> getAllDeal();
    Deal getDealById(int id);

    void updateDeal(Deal d);

        IEnumerable<Flight> GetAllFlight();

        

    }


}