using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MessageService.BLL
{
    public static class DependenciesBootstrapper
    {
        public static IServiceCollection AddMessageServiceBll(this IServiceCollection services)
        {
            services.AddSingleton(AutoMapperInitialization.CreateMapper());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            return services;
        }
    }
}
