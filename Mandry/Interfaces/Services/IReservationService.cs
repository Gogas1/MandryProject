using Mandry.Models.DB;
using Mandry.Models.Requests.Housing;
using Mandry.Models.DTOs.ApiDTOs.Reservations;

namespace Mandry.Interfaces.Services
{
    public interface IReservationService
    {
        Task<Reservation> AddReservation(AddReservationModel addReservationModel, User user);
        Task DeleteReservation(string id);

        Task<IEnumerable<ReservationDTO>> GetUserReservationsDtoByUserIdAsync(string userId);
    }
}
