using Mandry.Models.DTOs.ApiDTOs.Categories;

namespace Mandry.Interfaces.Services
{
    public interface ICategoryService
    {
        Task<CategoryDTO> CreateCategoryAsync(CategoryDTO categoryDTO);
        Task<ICollection<CategoryDTO>> GetCategoriesAsync();
    }
}
