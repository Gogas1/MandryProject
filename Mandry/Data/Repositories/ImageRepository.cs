using Mandry.Data.DbContexts;
using Mandry.Interfaces.Repositories;
using Mandry.Models.DB;

namespace Mandry.Data.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly MandryDbContext _context;

        public ImageRepository(MandryDbContext context)
        {
            _context = context;
        }

        public async Task<Image> CreateImage(Image image)
        {
            _context.Add(image);
            await _context.SaveChangesAsync();

            return image;
        }
    }
}
