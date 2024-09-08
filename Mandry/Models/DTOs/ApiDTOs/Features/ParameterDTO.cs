namespace Mandry.Models.DTOs.ApiDTOs.Features
{
    public class ParameterDTO
    {
        public string Id { get; set; } = string.Empty;
        public string NameKey { get; set; } = string.Empty;
        public string ParameterKey { get; set; } = string.Empty;
        public string DefaultValue { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public ICollection<TranslationDTO> Translations { get; set; } = new List<TranslationDTO>();
    }
}
