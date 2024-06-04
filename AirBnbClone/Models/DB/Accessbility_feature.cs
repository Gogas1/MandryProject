namespace AirBnbClone.Models.DB
{
    public class Accessbility_feature
    {
        public int id { get; set; }
        public string name_key { get; set; }
        public string description_key { get; set; }

        public List<Accessbility_feature_housing> Accessbility_feature_housings { get; set; }
    }
}
