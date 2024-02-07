using Client.Contracts;
using Client.Repositories;
using WebApplication4.Controllers;

namespace Client.Services;

internal interface IClientMapper
{
    /// <summary>
    /// Возвращает массив клиентов, полученного из БД.
    /// </summary>
    /// <param name="clientEntities">Массив клиентов БД.</param>
    /// <returns>Массив клиентов.</returns>
    ClientDto[] Create(ClientEntity[] clientEntities);

    /// <summary>
    /// Возвращает клиента, полученного из БД.
    /// </summary>
    /// <param name="clientEntity">Клиент БД.</param>
    /// <returns>Клиент.</returns>
    ClientDto Create(ClientEntity clientEntity);

    /// <summary>
    /// Возвращает клиента для добавления в БД.
    /// </summary>
    /// <param name="client">Клиент веб-сервиса.</param>
    /// <returns>Клиент.</returns>
    ClientEntity Create(ClientDto client);

    /// <summary>
    /// Возвращает массив отсортированных клиентов из БД.
    /// </summary>
    /// <param name="filterClientEntities">Массив клиентов из БД.</param>
    /// <returns>Массив клиентов.</returns>
    FilterClientDto[] Create(FilterClientEntity[] filterClientEntities);

    /// <summary>
    /// Возвращает клиента, полученного из БД.
    /// </summary>
    /// <param name="filterClientEntity">Клиент БД.</param>
    /// <returns>Клиент.</returns>
    FilterClientDto CreateFilter(FilterClientEntity filterClientEntity);
}