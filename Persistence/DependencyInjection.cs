using Microsoft.Extensions.DependencyInjection;
using Application.Interfaces.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Persistence.Repository.common;
using Persistence.Repository;
using Domain;

namespace Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(
            optionsBuilder => { optionsBuilder.UseNpgsql(configuration.GetConnectionString("PostgresqlConnection")); },
            ServiceLifetime.Scoped,
            ServiceLifetime.Scoped
        );

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IBaseRepository<Company>, CompanyRepository>();
        services.AddScoped<IBaseRepository<User>, UserRepository>();
        services.AddScoped<IBaseRepository<Role>, RoleRepository>();

        return services;
    }
}