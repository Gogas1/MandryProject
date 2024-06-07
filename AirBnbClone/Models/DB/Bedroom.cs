namespace AirBnbClone.Models.DB
{
    public class Bedroom
    {
        public Guid Id { get; set; }

        public Image Image { get; set; }
        public Housing Housing { get; set; }
        public ICollection<Bed> Beds { get; set; } = new List<Bed>();
    }
}
