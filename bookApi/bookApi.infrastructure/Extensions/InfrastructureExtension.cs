using Microsoft.Extensions.DependencyInjection;

namespace bookApi.infrastructure.Extensions
{
    public static class InfrastructureExtension
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            return services;
        }

    }
}
