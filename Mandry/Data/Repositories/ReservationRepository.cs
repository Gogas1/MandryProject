using Mandry.Data.DbContexts;
using Mandry.Interfaces.Repositories;
using Mandry.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace Mandry.Data.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly MandryDbContext _dbContext;

        public ReservationRepository(MandryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Reservation> CreateReservation(Reservation reservation)
        {
            _dbContext.Attach(reservation.Housing);
            reservation = _dbContext.Reservations.Add(reservation).Entity;
            await _dbContext.SaveChangesAsync();

            return reservation;
        }

        public async Task DeleteReservation(Guid id)
        {
            var target = new Reservation { Id = id };
            _dbContext.Entry(target).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
        }
    }
}
