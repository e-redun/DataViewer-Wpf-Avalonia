using Common.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace Common.Infrastructure
{
    public static class ServiceRegisterExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            return services;
        }

        public static IServiceCollection AddViewModels(this IServiceCollection services)
        {
            services.AddSingleton<MainWindowModel>();
            
            return services;
        }
    }
}