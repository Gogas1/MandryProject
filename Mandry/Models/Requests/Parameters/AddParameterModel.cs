using Mandry.Models.DTOs.ApiDTOs;

namespace Mandry.Models.Requests.Parameters
{
    public class AddParameterModel
    {
        public string NameKey { get; set; } = string.Empty;
        public string ParameterKey { get; set; } = string.Empty;
        public string DefaultValue { get; set; } = string.Empty;
        public ICollection<TranslationDTO> Translations { get; set; } = new List<TranslationDTO>();
    }
}
