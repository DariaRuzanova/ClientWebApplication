using Client.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace Client.Services;
/// <summary>
/// Методы расширения для IServiceCollection.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Регистрируем сервисы текущего проекта.
    /// </summary>
    /// <param name="services">DI сервисов.</param>
    public static IServiceCollection AddClientServices(this IServiceCollection services)
    {
        services.AddScoped<IClientService, ClientService>();
        services.AddSingleton<IClientMapper, ClientMapper>();
        services.AddScoped<IFilterClientService, FilterClientService>();
        return services;
    }
    
}