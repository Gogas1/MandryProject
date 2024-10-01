using Mandry.Extensions;
using Mandry.Interfaces.Repositories;
using Mandry.Interfaces.Services;
using Mandry.Models.Requests.Housing;
using Mandry.Models.DB;
using System.Text;
using Mandry.Models.DTOs.ApiDTOs.Reservations;

namespace Mandry.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IHousingRepository _housingRepository;

        public ReservationService(IReservationRepository reservationRepository, IHousingRepository housingRepository)
        {
            _reservationRepository = reservationRepository;
            _housingRepository = housingRepository;
        }

        public async Task<Reservation> AddReservation(AddReservationModel addReservationModel, User user)
        {
            var reservation = addReservationModel.ToReservation();
            bool housingExisting = await _housingRepository.IsHousingExistingByIdAsync(Guid.Parse(addReservationModel.HousingId));            
            if(!housingExisting)
            {
                throw new ArgumentException();
            }
            reservation.Housing = new Housing()
            {
                Id = Guid.Parse(addReservationModel.HousingId),
            };
            reservation.Guest = user;
            reservation.Code = GenerateRandomString(15);
            reservation = await _reservationRepository.CreateReservation(reservation);
            return reservation;
        }

        public async Task DeleteReservation(string id)
        {
            await _reservationRepository.DeleteReservation(Guid.Parse(id));
        }

        private string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            StringBuilder result = new StringBuilder(length);
            Random random = new Random();

            for (int i = 0; i < length; i++)
            {
                result.Append(chars[random.Next(chars.Length)]);
            }

            return result.ToString();
        }

        public async Task<IEnumerable<ReservationDTO>> GetUserReservationsDtoByUserIdAsync(string userId)
        {
            var userGuid = Guid.Parse(userId);
            var reservations = await _reservationRepository.GetReservationsByUserIdAsync(userGuid);

            return reservations.Select(r => new ReservationDTO
            {
                Id = r.Id,
                From = r.From,
                To = r.To,
                Code = r.Code,
                FullPrice = r.FullPrice,
                Housing = new HousingDTO
                {
                    Name = r.Housing.Name,
                    ImageUrl = r.Housing.Images.FirstOrDefault()?.Src ?? string.Empty // Первое изображение или пустая строка
                }
            }).ToList();
        }
    }
}
