using bookApi.Domian.Interfaces;
using bookApi.infrastructure.Repositories;
using bookApi.infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace bookApi.infrastructure.Extensions
{
    public static class InfrastructureExtension
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserReposirtory>();
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IGenreRepository, GenreRepository>();
            services.AddTransient<IPasswordEncryptionService, PasswordEncryptionService>();
            services.AddTransient<IJwtTokenService, JwtTokenService>();

            return services;
        }

    }
}
