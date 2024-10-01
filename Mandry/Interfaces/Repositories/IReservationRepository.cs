using Mandry.Models.DB;

namespace Mandry.Interfaces.Repositories
{
    public interface IReservationRepository
    {
        Task<Reservation> CreateReservation(Reservation reservation);
        Task DeleteReservation(Guid id);

        Task<IEnumerable<Reservation>> GetReservationsByUserIdAsync(Guid userId);
    }
}
