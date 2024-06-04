namespace AirBnbClone.Models.DB
{
    public class Accessbility_feature_housing
    {
        public int id { get; set; }
        public Accessbility_feature accessbility_feature_id { get; set; }
        public Images image_id { get; set; }
        public Housing housing_id { get; set; }
    }
}
