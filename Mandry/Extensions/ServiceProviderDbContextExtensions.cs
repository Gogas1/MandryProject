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
                MandryDbContext dbContext = scope.ServiceProvider.GetRequiredService<MandryDbContext>();
                dbContext.Database.Migrate();
            }
        }
    }
}
