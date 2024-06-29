using Mandry.Models.Inheritance;
using Microsoft.EntityFrameworkCore;

namespace Mandry.Models.DB
{
    public class Parameter : Translatable
    {
        public string NameKey { get; set; } = string.Empty;
        public string DefaultValue { get; set; } = string.Empty;

        [DeleteBehavior(DeleteBehavior.NoAction)]
        public Feature Feature { get; set; }
        public ICollection<ParameterFeatureHousing> ParameterValuesForHousing { get; set; }
    }
}
