using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Picoage.MediatR.Application.Interfaces.Services;
using Picoage.MediatR.Application.Services;
using System.Reflection;

namespace Picoage.MediatR.Application.Extensions
{
    public static class ServiceExtension
    {
        public static void RegisterApplicationInstances(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMediatR(Assembly.GetExecutingAssembly());
            serviceCollection.AddTransient<IAuthenticationService, AuthenticationService>();
        }
    }
}
