using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PedalsApi.Domain.Category.Repositories;
using PedalsApi.Domain.Pedal.Repositories;
using PedalsApi.Infrastructure.EntityFramework.Commands;
using PedalsApi.Infrastructure.EntityFramework.DbContexts;
using PedalsApi.Infrastructure.EntityFramework.Queries;
namespace PedalsApi.Infrastructure.EntityFramework;

internal static class ConfigureEntityFramework
{
    public static void AddEntityFramework(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<PedalsContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("SqlServerConnection"));
        });
    }
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ICategoryCommandRepository, CategoryCommandRepository>();
        services.AddScoped<ICategoryQueryRepository, CategoryQueryRepository>();
        services.AddScoped<IPedalCommandRepository, PedalCommandRepository>();
        services.AddScoped<IPedalQueryRepository, PedalQueryRepository>();
    }
}
