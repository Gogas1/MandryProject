namespace AirBnbClone.Models.DB
{
    public class Housing
    {
        public int id { get; set; }
        public User owner_id { get; set; }
        public Categories category_id { get; set; }

    }
}
