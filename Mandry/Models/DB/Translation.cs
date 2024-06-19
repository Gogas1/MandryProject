using Mandry.Models.Inheritance;

namespace Mandry.Models.DB
{
    public class Translation
    {
        public Guid Id { get; set; }
        public string Language { get; set; } = string.Empty;
        public string TranslationKey { get; set; } = string.Empty;
        public string TranslationString { get; set; } = string.Empty;

        public Translatable Translatable { get; set; }
    }
}
