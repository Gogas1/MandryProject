using Mandry.Data.Repositories;
using Mandry.Interfaces.Repositories;

namespace Mandry.Extensions
{
    public static class ServiceCollectionRepositoriesExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepo, UsersRepository>();
            services.AddScoped<IFeatureRepository, FeatureRepository>();
            services.AddScoped<IDestinationRepository, DestinationRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IImageRepository, ImageRepository>();
            services.AddScoped<IHousingRepository, HousingRepository>();
            services.AddScoped<IReviewsRepository, ReviewsRepository>();
            services.AddScoped<IFavouritesRepository, FavouritesRepository>();
        }
    }
}
