using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PedalsApi.Infrastructure.EntityFramework;

namespace PedalsApi.Infrastructure.Services.Configuration;

public static class ConfigureInfrastructure
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddEntityFramework(configuration);
        services.AddRepositories();
    }
}
