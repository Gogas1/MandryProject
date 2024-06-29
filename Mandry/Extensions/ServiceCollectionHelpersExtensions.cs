using Mandry.Helpers;
using Mandry.Interfaces.Helpers;

namespace Mandry.Extensions
{
    public static class ServiceCollectionHelpersExtensions
    {
        public static void AddHelpers(this IServiceCollection services)
        {
            services.AddTransient<IStringObfuscator, StringObfuscator>();
        }
    }
}
