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
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IGenreRepository, GenreRepository>();
            services.AddTransient<ILikeRepository, LikeRepository>();
            services.AddTransient<IReviewRepository, ReviewRepository>();
            services.AddTransient<ICommentRepository, CommentRepository>();
            services.AddTransient<IPasswordEncryptionService, PasswordEncryptionService>();
            services.AddTransient<IJwtTokenService, JwtTokenService>();

            return services;
        }

    }
}
