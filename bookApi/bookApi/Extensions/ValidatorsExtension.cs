using bookApi.Validators;
using FluentValidation;

namespace bookApi.Extensions
{
    public static class ValidatorsExtension
    {
        public static IServiceCollection AddCustomValidators(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<LoginValidator>();
            services.AddValidatorsFromAssemblyContaining<CreateUserValidator>();
            services.AddValidatorsFromAssemblyContaining<SignInValidator>();
            services.AddValidatorsFromAssemblyContaining<UpdatePasswordValidator>();


            return services;
        }
    }
}
