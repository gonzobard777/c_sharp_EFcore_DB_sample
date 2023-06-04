using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Persistence.Repository.common;
using Persistence.Interfaces;
using Persistence.Repository;

namespace Persistence;

/**
 * Время существования, настройка и инициализация DbContext:
 *   https://learn.microsoft.com/ru-ru/ef/core/dbcontext-configuration/
 */
public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(
            optionsBuilder => { optionsBuilder.UseNpgsql(configuration.GetConnectionString("PostgresqlConnection")); },
            ServiceLifetime.Scoped,
            ServiceLifetime.Scoped
        );

        services.AddScoped<IBaseRepository, BaseRepository>();
        services.AddScoped<UserRepository>();

        return services;
    }
}