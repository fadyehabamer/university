using Eticket.Repository;
using Eticket.Models;
namespace Eticket.Repository.IRepository
{
    public interface ICinemaRepository
    {
        List<Cinema> GetAllCinemas();
        Cinema GetCinemaById(int cinemaId);
    }
}
