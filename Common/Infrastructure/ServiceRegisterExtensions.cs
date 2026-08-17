using Common.Services;
using Common.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Common.Infrastructure
{
    public static class ServiceRegisterExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<IDataService, MockDataService>();

            return services;
        }

        public static IServiceCollection AddViewModels(this IServiceCollection services)
        {
            services.AddSingleton<MainWindowModel>();
            services.AddSingleton<DataBasesViewModel>();
            services.AddSingleton<TablesViewModel>();
            services.AddSingleton<TableContentViewModel>();
            services.AddSingleton<PropertiesViewModel>();
            
            return services;
        }
    }
}