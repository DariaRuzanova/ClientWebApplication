using Client.Contracts;
using DataModel;
using LinqToDB;
using LinqToDB.AspNet;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;//Для работы с IOC.

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
    public static IServiceCollection AddClientRepository(this IServiceCollection services) //В методе проходит регистрация сервисов для последующего представления в качестве внешних зависимостей.
    {
        services.AddScoped<IClientRepository, ClientRepository>();
        services.AddScoped<IFilterClientRepository, FilterClientRepository>();
        services.AddHttpClient(nameof(FilterClientRepository),(di, httpClient) =>
        {
            IConfiguration configuration = di.GetRequiredService<IConfiguration>();//обращаемся к DI и запрашиваем конфигурацию
            ClientSettings settings = configuration.GetSection(nameof(ClientSettings)).Get<ClientSettings>();//Обращаемся к секции конфигурации clientSettings и десерилизуем в класс ClientSettings
            httpClient.BaseAddress = settings.ServiceAddress; //Для HttpClient указываем адрес машины.
        });
        services.AddLinqToDBContext<ClientContextDb>((di, options) =>
                                                         options.UsePostgreSQL(di.GetRequiredService<IConfiguration>()
                                                                                 .GetConnectionString("Clients")!));
        return services;
    }
}