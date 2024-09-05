using Mandry.Models.DTOs.ApiDTOs.Categories;

namespace Mandry.ApiResponses.Category
{
    public class GetCategoriesResponse
    {
        public ICollection<CategoryDTO> Categories { get; set; } = new List<CategoryDTO>();
    }
}
