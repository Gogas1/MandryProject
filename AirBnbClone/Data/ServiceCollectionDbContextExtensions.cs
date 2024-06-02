using AirBnbClone.Data.DbContexts;
using Microsoft.Data.Sql;
using Microsoft.EntityFrameworkCore;

namespace AirBnbClone.Data
{
    public static class ServiceCollectionDbContextExtensions
    {
        public static void SetupSqlServerDbContext(this WebApplicationBuilder builder)
        {
            IConfiguration configuration = builder.Configuration;
            string connectionString = configuration.GetConnectionString("SqlServer") ?? throw new Exception("SqlServer connection string is missing");

            builder.Services.AddDbContext<AirbnbDbContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
