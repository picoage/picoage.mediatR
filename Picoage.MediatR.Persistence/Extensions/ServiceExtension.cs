using Microsoft.Extensions.DependencyInjection;
using Picoage.MediatR.Application.Interfaces.Repositories;

namespace Picoage.MediatR.Persistence.Extensions
{
    public static class ServiceExtension
    {
        public static void RegisterPersistenceInstances(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ICustomerRepository, CustomerRepository>();
        }
    }
}
