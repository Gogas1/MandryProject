namespace Mandry.Models.Requests.Housing
{
    public class HousingFilterModel
    {
        public string? Destination { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Adults { get; set; }
        public int? Children { get; set; }
        public int? Toddlers { get; set; }
        public int? Pets { get; set; }
        public string? CategoryId { get; set; }
        public int? MinBeds { get; set; }
        public int? MinBedrooms { get; set; }
        public int? MinBathrooms { get; set; }
        public List<string>? FeatureIds { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        public List<string>? Languages { get; set; }
    }
}
