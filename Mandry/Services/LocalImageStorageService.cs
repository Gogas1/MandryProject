using Mandry.Interfaces.Services;

namespace Mandry.Services
{
    public class LocalImageStorageService : IImageStorageService
    {
        private readonly IWebHostEnvironment _environment;

        public LocalImageStorageService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public async Task<string> SaveImageAsync(IFormFile file, string subDirectory)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentNullException("File is empty or null");
            }

            var uploadDir = Path.Combine(_environment.WebRootPath, subDirectory);
            if (!Directory.Exists(uploadDir))
            {
                Directory.CreateDirectory(uploadDir);
            }

            var filePath = Path.Combine(uploadDir, file.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Path.Combine(subDirectory, file.FileName);
        }
    }
}
