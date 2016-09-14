using Domain.Entities;
using Service.Pattern;

namespace Service
{
    public interface ILocationService :  IService<Location>
       
    {

         Location GetByIdLocation(int id);

    }
}
