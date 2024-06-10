using AirBnbClone.Interfaces.Validation;
using AirBnbClone.Validation;

namespace AirBnbClone.Extensions
{
    public static class ServiceCollectionValidatorExtensions
    {
        public static void AddCredentialValidator(this IServiceCollection services, Action<CredentialValidatorOptions>? optionsAction = null)
        {
            CredentialValidatorOptions options = new CredentialValidatorOptions();
            optionsAction?.Invoke(options);

            services.AddScoped<ICredentialValidator, CredentialValidator>(provider => new CredentialValidator(options));
        }
    }
}
