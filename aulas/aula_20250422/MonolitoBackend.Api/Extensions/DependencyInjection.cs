using System;
using MonolitoBackend.Core.Repositories;
using MonolitoBackend.Core.Services;
using MonolitoBackend.Infrastructure.Repositories;

namespace MonolitoDemo.Api.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services) {
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthService, AuthService>();
        return services;
    }
}
