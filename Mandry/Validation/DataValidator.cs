using Mandry.Interfaces.Validation;
using Mandry.Models.DTOs.ApiDTOs.Categories;
using Mandry.Models.DTOs.ApiDTOs.Features;
using Mandry.Models.Requests.Feature;

namespace Mandry.Validation
{
    public class DataValidator : IDataValidator
    {
        public ValidationErrors ValidateFeatureData(AddFeatureModel featureData)
        {
            List<ValidationError> errors = new List<ValidationError>();
            ValidationErrors validationErrors = new ValidationErrors("feature", errors);

            if(string.IsNullOrEmpty(featureData.NameCode))
            {
                errors.Add(new ValidationError("nameCode", "not-empty"));
            }

            //if (string.IsNullOrEmpty(featureData.DescriptionCode))
            //{
            //    errors.Add(new ValidationError("descriptionCode", "not-empty"));
            //}

            if (!featureData.Translations.Any())
            {
                errors.Add(new ValidationError("translations", "any"));
            }

            return validationErrors;
        }

        public ValidationErrors ValidateCategoryData(CategoryDTO categoryData)
        {
            List<ValidationError> errors = new List<ValidationError>();
            ValidationErrors validationErrors = new ValidationErrors("category", errors);

            if (string.IsNullOrEmpty(categoryData.NameKey))
            {
                errors.Add(new ValidationError("name-key", "not-empty"));
            }

            if (!categoryData.CategoryTranslations.Any())
            {
                errors.Add(new ValidationError("category-translations", "any"));
            }

            if (categoryData.IsCategoryPropertyRequired)
            {
                if (string.IsNullOrEmpty(categoryData.CategoryPropertyDescriptionKey))
                {
                    errors.Add(new ValidationError("description-key", "not-empty"));
                }

                if(!categoryData.CategoryPropertyTranslations.Any())
                {
                    errors.Add(new ValidationError("category-property-translations", "any"));
                }
            }

            return validationErrors;
        }
    }
}
