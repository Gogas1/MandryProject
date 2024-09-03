using Mandry.Models.DB;

namespace Mandry.Interfaces.Repositories
{
    public interface IDestinationRepository
    {
        Task<Destination> CreateDestinationAsync(Destination destination);
        Task<ICollection<Destination>> GetAllDestinationsAsync();
        Task<ICollection<Destination>> GetDestinationsByNameAsync(string name);
    }
}
