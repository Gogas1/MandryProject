using Mandry.Models.DTOs.ApiDTOs.Categories;
using Mandry.Models.DTOs.ApiDTOs.Features;
using Mandry.Models.Requests.Feature;

namespace Mandry.Interfaces.Validation
{
    public interface IDataValidator
    {
        ValidationErrors ValidateFeatureData(AddFeatureModel featureData);
        ValidationErrors ValidateCategoryData(CategoryDTO categoryData);
    }
}
