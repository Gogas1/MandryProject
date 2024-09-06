using Mandry.Models.DB;

namespace Mandry.Interfaces.Repositories
{
    public interface IImageRepository
    {
        Task<Image> CreateImage(Image image);
    }
}
