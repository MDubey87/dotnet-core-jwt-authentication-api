using JWTAuthentication.TokenManager;
using Microsoft.Extensions.DependencyInjection;

namespace JwtAuthentication.Services.Extensions
{
    public static class UserServiceExtensions
    {
        public static IServiceCollection AddUserServiceDepedencies(this IServiceCollection services) 
        {
            services.AddSingleton<JWTTokenManager>();
            services.AddSingleton<IUserService, UserService>();
            return services;
        }

    }
}
