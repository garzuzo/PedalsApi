using PedalsApi.Application.Services.Configuration;
using PedalsApi.Infrastructure.Services.Configuration;
namespace PedalsApi.Extensions;

public static class ConfigureServices
{
    public static void AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddApplication();
        services.AddInfrastructure(configuration);
    }

}
