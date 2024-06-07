using AirBnbClone.Models.Inheritance;

namespace AirBnbClone.Models.DB
{
    public class CategoryDescriptionProperty : Translatable
    {
        public string DescriptionKey { get; set; } = string.Empty;
    }
}
