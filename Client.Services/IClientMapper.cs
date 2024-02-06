using Client.Contracts;
using Client.Repositories;

namespace Client.Services;

internal interface IClientMapper
{
    /// <summary>
    /// Возвращает клиента, полученного из БД.
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
}