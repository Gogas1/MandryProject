using Mandry.Models.DTOs.ApiDTOs;

namespace Mandry.Models.Requests.Categories
{
    public class AddCategoryModel
    {
        public string NameKey { get; set; } = string.Empty;
        public bool IsCategoryPropertyRequired { get; set; }
        public string CategoryPropertyDescriptionKey { get; set; } = string.Empty;

        public ICollection<TranslationDTO> CategoryTranslations { get; set; } = new List<TranslationDTO>();
        public ICollection<TranslationDTO> CategoryPropertyTranslations { get; set; } = new List<TranslationDTO>();
    }
}
