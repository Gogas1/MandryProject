namespace AirBnbClone.Models.DB
{
    public class Availability
    {
        public Guid Id { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public Housing Housing { get; set; }
    }
}
