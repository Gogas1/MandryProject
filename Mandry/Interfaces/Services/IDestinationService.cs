using Mandry.Models.DB;

namespace Mandry.Interfaces.Services
{
    public interface IDestinationService
    {
        Task<Destination> SaveDestinationAsync(Destination destination);
        Task<List<Destination>> FilterDestinationsByNameAsync(string name);
    }
}
