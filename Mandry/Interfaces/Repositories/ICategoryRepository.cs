using Mandry.Models.DB;

namespace Mandry.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category> CreateCategoryAsync(Category feature);
        Task<ICollection<Category>> GetAllCategoriesAsync();
        Task<ICollection<Category>> GetAllCategoriesWithTranslations();
        Task DeleteCategory(Guid id);
    }
}
