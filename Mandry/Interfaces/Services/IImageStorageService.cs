namespace Mandry.Interfaces.Services
{
    public interface IImageStorageService
    {
        Task<string> SaveImageAsync(IFormFile file, string subDirectory);
    }
}
