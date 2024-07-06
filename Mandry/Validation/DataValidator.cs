using Mandry.Interfaces.Validation;
using Mandry.Models.DTOs.ApiDTOs.Features;

namespace Mandry.Validation
{
    public class DataValidator : IDataValidator
    {
        public ValidationErrors ValidateFeatureData(FeatureDataDTO featureData)
        {
            List<ValidationError> errors = new List<ValidationError>();
            ValidationErrors validationErrors = new ValidationErrors("feature", errors);

            if(string.IsNullOrEmpty(featureData.NameCode))
            {
                errors.Add(new ValidationError("nameCode", "not-empty"));
            }

            if (string.IsNullOrEmpty(featureData.DescriptionCode))
            {
                errors.Add(new ValidationError("descriptionCode", "not-empty"));
            }

            if (!featureData.Translations.Any())
            {
                errors.Add(new ValidationError("translations", "any"));
            }

            return validationErrors;
        }
    }
}
