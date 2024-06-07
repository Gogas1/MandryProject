namespace AirBnbClone.Models.DB
{
    public class Bed
    {
        public Guid Id { get; set; }
        public int NumberOfPeople { get; set; }
        public string Width { get; set; } = string.Empty;
        public string Height { get; set; } = string.Empty;
        public Bedroom Bedroom { get; set; }
    }
}
