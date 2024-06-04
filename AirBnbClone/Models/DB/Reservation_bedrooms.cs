namespace AirBnbClone.Models.DB
{
    public class Reservation_bedrooms
    {
        public int id { get; set; }
        public Reservation reservation_id { get; set; }
        public Bedrooms bedroom_id { get; set; }
    }
}
