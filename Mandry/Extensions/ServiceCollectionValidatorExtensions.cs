using Mandry.Interfaces.Validation;
using Mandry.Validation;

namespace Mandry.Extensions
{
    public static class ServiceCollectionValidatorExtensions
    {
        public static void AddCredentialValidator(this IServiceCollection services, Action<CredentialValidatorOptions>? optionsAction = null)
        {
            CredentialValidatorOptions options = new CredentialValidatorOptions();
            optionsAction?.Invoke(options);

            services.AddScoped<ICredentialValidator, CredentialValidator>(provider => new CredentialValidator(options));
        }

        public static void AddDataValidation(this IServiceCollection services)
        {
            services.AddScoped<IDataValidator, DataValidator>();
        }
    }
}
