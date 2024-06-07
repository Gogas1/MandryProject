namespace AirBnbClone.Models.DB
{
    public class Image
    {
        public Guid Id { get; set; }
        public string Src { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
