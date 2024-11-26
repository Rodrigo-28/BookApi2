using Microsoft.Extensions.DependencyInjection;

namespace bookApi.Application.Extensions
{
    public static class ApplicationExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            return services;
        }

    }
}
