using Mandry.Interfaces.Repositories;
using Mandry.Interfaces.Services;
using Mandry.Models.DB;

namespace Mandry.Services
{
    public class DestinationService : IDestinationService
    {
        private readonly IDestinationRepository _destinationRepository;

        public DestinationService(IDestinationRepository destinationRepository)
        {
            _destinationRepository = destinationRepository;
        }

        public async Task<List<Destination>> FilterDestinationsByNameAsync(string name)
        {
            var result = await _destinationRepository.GetDestinationsByNameAsync(name);
            return result.ToList();
        }

        public async Task<Destination> SaveDestinationAsync(Destination destination)
        {
            return await _destinationRepository.CreateDestinationAsync(destination);
        }
    }
}
