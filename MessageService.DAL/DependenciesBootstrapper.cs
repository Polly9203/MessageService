using MessageService.DAL.Repositories.MessageRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MessageService.DAL
{
    public static class DependenciesBootstrapper
    {
        public static IServiceCollection AddMessageServiceDAL(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IMessageRepository, MessageRepository>();

            return services;
        }
    }
}
