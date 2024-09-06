using Mandry.Models.DB;

namespace Mandry.Interfaces.Services
{
    public interface IImageService
    {
        Task<Image> SaveImage(IFormFile file, string subDirectory);
    }
}
