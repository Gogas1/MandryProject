using Mandry.Data.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Mandry.Extensions
{
    public static class ServiceProviderDbContextExtensions
    {
        public static void DbMigration(this IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                AirbnbDbContext dbContext = scope.ServiceProvider.GetRequiredService<AirbnbDbContext>();
                dbContext.Database.Migrate();
            }
        }
    }
}
