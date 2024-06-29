using Microsoft.EntityFrameworkCore;

namespace Mandry.Models.DB
{
    public class FeatureHousing
    {
        public Guid Id { get; set; }
        public string CustomName { get; set; } = string.Empty;
        public string CustomDescription { get; set; } = string.Empty;

        [DeleteBehavior(DeleteBehavior.NoAction)]
        public Feature Feature { get; set; }
        [DeleteBehavior(DeleteBehavior.NoAction)]
        public Housing Housing { get; set; }
        public ICollection<ParameterFeatureHousing> ParametersValues { get; set; }
    }
}
