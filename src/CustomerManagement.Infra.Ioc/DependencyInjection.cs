using CustomerManagement.Application.Interfaces;
using CustomerManagement.Application.Notifications;
using CustomerManagement.Application.Services;
using CustomerManagement.Domain.Interfaces.Repositories;
using CustomerManagement.Infra.Data.Context;
using CustomerManagement.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerManagement.Infra.Ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection InjectDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<INotifier, Notifier>();

            return services
                .InjectServices()
                .InjectRepositories()
                .InjectDbContext(configuration);
        }

        private static IServiceCollection InjectServices(this IServiceCollection services)
        {
            services.AddScoped<ICustomerService, CustomerService>();
            return services;
        }

        private static IServiceCollection InjectRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            return services;
        }

        private static IServiceCollection InjectDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DatabaseConnection"));
            });

            return services;
        }
    }
}
