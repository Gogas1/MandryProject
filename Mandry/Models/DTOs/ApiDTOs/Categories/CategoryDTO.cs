namespace Mandry.Models.DTOs.ApiDTOs.Categories
{
    public class CategoryDTO
    {
        public string Id { get; set; } = string.Empty;
        public string NameKey { get; set; } = string.Empty;
        public bool IsCategoryPropertyRequired { get; set; }
        public string CategoryPropertyDescriptionKey { get; set; } = string.Empty;

        public ICollection<TranslationDTO> CategoryTranslations { get; set; } = new List<TranslationDTO>();
        public ICollection<TranslationDTO> CategoryPropertyTranslations { get; set; } = new List<TranslationDTO>();
    }
}
