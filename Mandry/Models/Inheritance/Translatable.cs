using Mandry.Models.DB;

namespace Mandry.Models.Inheritance
{
    public abstract class Translatable
    {
        public Guid Id { get; set; }
        public ICollection<Translation> Translation { get; set; } = new List<Translation>();
    }
}
