using Mandry.Interfaces.Services;
using Mandry.Services;

namespace Mandry.Extensions
{
    public static class ServiceCollectionServicesExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
