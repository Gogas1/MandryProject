namespace AirBnbClone.Models.DB
{
    public class Housing
    {
        public int id { get; set; }
        public User owner_id { get; set; }
        public Categories category_id { get; set; }
        public decimal price_night { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public string category_property { get; set; }
        public string location { get; set; }
        public int max_guests { get; set; }

        public List<Availabilities> Availabilities { get; set; }
        public List<Feature_housing> Feature_housings { get; set; }
        public List<Accessbility_feature_housing> Accessbility_feature_housings { get; set; }
        public List<Bedrooms> Bedrooms { get; set; }
    }
}
