using Microsoft.EntityFrameworkCore;

namespace Mandry.Models.DB
{
    public class Reservation
    {
        public Guid Id { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public User Guest { get; set; }
        public Housing Housing { get; set; }
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public ICollection<Bedroom> Bedrooms { get; set; } = new List<Bedroom>();
    }
}
