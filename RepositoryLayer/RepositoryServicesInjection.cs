using Microsoft.Extensions.DependencyInjection;
using RepositoryLayer.Concretes;
using RepositoryLayer.Contracts;

namespace RepositoryLayer
{
    public static class RepositoryServicesInjection
    {
        public static IServiceCollection RegisterRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGeneralRepository<,>), typeof(GeneralRepository<,>));
            return services;
        }
    }
}
