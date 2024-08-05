
using Microsoft.Extensions.DependencyInjection;
using PedalApi.Application.Interfaces;
using PedalsApi.Application.UseCases;

namespace PedalsApi.Application.Services.Configuration;

public static class ConfigureApplication
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ICreateCategoryUseCase, CreateCategoryUseCase>();
        services.AddScoped<IGetCategoryUseCase, GetCategoryUseCase>();
        services.AddScoped<ICreatePedalUseCase, CreatePedalUseCase>();
        services.AddScoped<IGetPedalUseCase, GetPedalUseCase>();
    }
}
