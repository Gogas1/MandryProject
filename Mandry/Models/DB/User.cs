using Microsoft.EntityFrameworkCore;

namespace Mandry.Models.DB
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string? Phone { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public DateOnly BirthDate { get; set; }
        public string? PasswordHash { get; set; } = string.Empty;
        public bool IsOwner { get; set; }
        public bool IsAgreementAccepted { get; set; }
        public DateTime OwnerFrom { get; set; }
        public float AverageRating { get; set; }

        public Image? ProfileImage {  get; set; }
        public ICollection<Availability> Availability { get; set; } = new List<Availability>();
        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public ICollection<Housing> Housings { get; set; } = new List<Housing>();
        public ICollection<Review> ReviewsReceived { get; set; } = new List<Review>();
        public ICollection<Review> ReviewsCreated { get; set; } = new List<Review>();
    }
}
