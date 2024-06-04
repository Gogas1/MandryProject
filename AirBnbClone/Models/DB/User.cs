namespace AirBnbClone.Models.DB
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string password_hash { get; set; }
        public int profile_image_id { get; set; }
        public bool is_owner {  get; set; }

        public List<Reservation> Reservations { get; set; }
    }
}
