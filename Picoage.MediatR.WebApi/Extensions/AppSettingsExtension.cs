using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Picoage.MediatR.Application.AppSettings;

namespace Picoage.MediatR.WebApi.ServiceCollections
{
    public static class AppSettingsExtension
    {
        public static AuthenticationSettings GetAuthenticationSettings(this IServiceCollection services, IConfiguration configuration)
        {
            IConfiguration appSettingsSection = configuration.GetSection("Authentication");
            services.Configure<AuthenticationSettings>(appSettingsSection);
            return appSettingsSection.Get<AuthenticationSettings>();
        }
    }
}
