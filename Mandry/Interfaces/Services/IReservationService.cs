using Mandry.Models.DB;
using Mandry.Models.Requests.Housing;

namespace Mandry.Interfaces.Services
{
    public interface IReservationService
    {
        Task<Reservation> AddReservation(AddReservationModel addReservationModel, User user);
        Task DeleteReservation(string id);
    }
}
