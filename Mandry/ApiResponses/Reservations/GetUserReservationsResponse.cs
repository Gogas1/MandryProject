using Mandry.Models.DTOs.ApiDTOs.Reservations;

namespace Mandry.ApiResponses.Reservations
{
    public class GetUserReservationsResponse
    {
        public bool HasReservations { get; set; }
        public List<ReservationDTO> Reservations { get; set; } = new List<ReservationDTO>();
    }
}
