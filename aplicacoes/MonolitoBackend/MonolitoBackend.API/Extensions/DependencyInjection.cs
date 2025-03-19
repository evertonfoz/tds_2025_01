using MonolitoBackend.Core.Repositories;
using MonolitoBackend.Infrastructure.Repositories;
using MonolitoBackend.Core.Services;

namespace MonolitoBackend.API.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IGenreRepository, GenreRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<CategoryService>();
        services.AddScoped<GenreService>();
        services.AddScoped<AuthService>();
        return services;
    }
}