using bookApi.Application.Interfaces;
using bookApi.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace bookApi.Application.Extensions
{
    public static class ApplicationExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<IGenreService, GenreService>();

            return services;
        }

    }
}
