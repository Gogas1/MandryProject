using Mandry.Interfaces.Validation;
using Mandry.Models.DTOs.ApiDTOs.Categories;

namespace Mandry.ApiResponses.Category
{
    public class CreateCategoryResponse
    {
        public bool Success { get; set; }
        public bool IsValidationFailed { get; set; }
        public ICollection<ValidationErrors> ValidationErrorsGroups { get; set; } = new List<ValidationErrors>();
        public CategoryDTO? CategoryData { get; set; }
    }
}
