using BusinessLayer.Contracts;
using BusinessLayer.Contretes;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLayer
{
    public static class BuisinessLayerInjection
    {
        public static IServiceCollection RegiserBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeManager, EmployeeManager>();
            return services;
        }
    }
}
