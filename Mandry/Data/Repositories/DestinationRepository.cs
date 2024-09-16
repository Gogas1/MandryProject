using Mandry.Data.DbContexts;
using Mandry.Interfaces.Repositories;
using Mandry.Models.DB;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;

namespace Mandry.Data.Repositories
{
    public class DestinationRepository : IDestinationRepository
    {
        private readonly MandryDbContext _context;

        public DestinationRepository(MandryDbContext context)
        {
            _context = context;
        }

        public async Task<Destination> CreateDestinationAsync(Destination destination)
        {
            _context.Destinations.Add(destination);
            await _context.SaveChangesAsync();

            return destination;
        }

        public async Task<ICollection<Destination>> GetAllDestinationsAsync()
        {
            return await _context.Destinations.ToListAsync();
        }

        public async Task<ICollection<Destination>> GetDestinationsByNameAsync(string name)
        {
            return await _context.Destinations.Where(d => EF.Functions.Like(d.Name, $"%{name}%")).ToListAsync();
        }

        public async Task CreateUniqueAsync(Destination destination)
        {
            if(!_context.Destinations.Any(d => d.Name == destination.Name.Trim()))
            {
                _context.Destinations.Add(destination);
                await _context.SaveChangesAsync();
            }
        }
    }
}
