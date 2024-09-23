using Mandry.Data.DbContexts;
using Mandry.Interfaces.Repositories;
using Mandry.Models.DB;
using Microsoft.EntityFrameworkCore;

namespace Mandry.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MandryDbContext _context;

        public CategoryRepository(MandryDbContext context)
        {
            _context = context;
        }

        public async Task<Category> CreateCategoryAsync(Category feature)
        {
            _context.Categories.Add(feature);
            await _context.SaveChangesAsync();

            return feature;
        }

        public async Task<ICollection<Category>> GetAllCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<ICollection<Category>> GetAllCategoriesWithTranslations()
        {
            return await _context.Categories
                .Include(c => c.Translation)
                .Include(c => c.CategoryPropertyTranslations)
                .ThenInclude(c => c.Translation)
                .ToListAsync();
        }

        public async Task DeleteCategory(Guid id)
        {
            var target = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if(target != null)
            {
                _context.Categories.Remove(target);
                await _context.SaveChangesAsync();
            }
        }
    }
}
