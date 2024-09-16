using Microsoft.EntityFrameworkCore;

namespace Mandry.Models.DB
{
    public class Review
    {
        public Guid Id { get; set; }
        public Guid? FromId { get; set; }
        public User From { get; set; }
        public float Rating { get; set; }
        public string Text { get; set; }

        public Guid? ToId { get; set; }
        public User To { get; set; }

        [DeleteBehavior(DeleteBehavior.NoAction)]
        public Housing HousingTo { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
