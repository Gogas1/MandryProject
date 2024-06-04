namespace AirBnbClone.Models.DB
{
    public class Reservation
    {
        public int id { get; set; }
        public User guest_id { get; set; }
        public Housing housing_id { get; set; }
    }
}
