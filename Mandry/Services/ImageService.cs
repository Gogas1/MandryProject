using Mandry.Interfaces.Repositories;
using Mandry.Interfaces.Services;
using Mandry.Models.DB;

namespace Mandry.Services
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository _imageRepository;
        private readonly IImageStorageService _imageStorageService;

        public ImageService(IImageRepository imageRepository, IImageStorageService imageStorageService)
        {
            _imageRepository = imageRepository;
            _imageStorageService = imageStorageService;
        }

        public async Task<Image> SaveImage(IFormFile file, string subDirectory)
        {
            string path = await _imageStorageService.SaveImageAsync(file, subDirectory);
            Image newImage = await _imageRepository.CreateImage(new Image()
            {
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Src = path
            });

            return newImage;
        }
    }
}
