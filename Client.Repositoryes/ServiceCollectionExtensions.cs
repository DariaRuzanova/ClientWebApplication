using Microsoft.Extensions.DependencyInjection;

namespace Client.Repositories;
/// <summary>
/// Методы расширения для IServiceCollection.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Регистрируем сервисы текущего проекта.
    /// </summary>
    /// <param name="services">DI сервисов.</param>
    public static IServiceCollection AddClientRepository(this IServiceCollection services)
    {
        services.AddScoped<IClientRepository, ClientRepository>();
        return services;
    }
}