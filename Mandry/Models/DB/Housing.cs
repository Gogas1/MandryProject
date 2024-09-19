using Microsoft.EntityFrameworkCore;

namespace Mandry.Models.DB
{
    public class Housing
    {
        public Guid Id { get; set; }
        public decimal PricePerNight { get; set; }
        public decimal CleaningFee { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string OneLineDescription { get; set; }
        public string ShortDescription { get; set; }
        public string? CategoryProperty { get; set; }
        public string LocationPlace { get; set; }
        public string LocationCountry { get; set; }
        public string LocationCoords { get; set; }
        public int MaxGuests { get; set; }
        public int Bathrooms { get; set; }
        public float AverageRating { get; set; }

        public User Owner { get; set; }
        public Category Category { get; set; }
        [DeleteBehavior(DeleteBehavior.Cascade)]
        public ICollection<Availability> Availabilities { get; set; } = new List<Availability>();
        [DeleteBehavior(DeleteBehavior.Cascade)]
        public ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
        [DeleteBehavior(DeleteBehavior.Cascade)]
        public ICollection<FeatureHousing> FeatureHousings { get; set; } = new List<FeatureHousing>();
        [DeleteBehavior(DeleteBehavior.Cascade)]
        public ICollection<AccessbilityFeatureHousing> AccessbilitiyFeatureHousings { get; set; } = new List<AccessbilityFeatureHousing>();
        [DeleteBehavior(DeleteBehavior.Cascade)]
        public ICollection<Bedroom> Bedrooms { get; set; } = new List<Bedroom>();
        [DeleteBehavior(DeleteBehavior.Restrict)]
        public ICollection<Image> Images { get; set; } = new List<Image>();
        [DeleteBehavior(DeleteBehavior.Cascade)]
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        [DeleteBehavior(DeleteBehavior.Cascade)]
        public ICollection<User> FavouriteTo { get; set; } = new List<User>();
    }
}
