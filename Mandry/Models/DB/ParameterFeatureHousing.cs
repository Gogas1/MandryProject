using Microsoft.EntityFrameworkCore;

namespace Mandry.Models.DB
{
    public class ParameterFeatureHousing
    {
        public Guid Id { get; set; }
        public string Value { get; set; } = string.Empty;

        [DeleteBehavior(DeleteBehavior.NoAction)]
        public Parameter Parameter { get; set; }
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public FeatureHousing FeatureHousing { get; set; }
    }
}
