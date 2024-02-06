using Client.Contracts;

namespace Client.Repositories;

/// <summary>
/// Репозиторий данных о клиентах.
/// </summary>
public interface IClientRepository
{
    /// <summary>
    /// Возвращает массив клиентов из репозитория.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Клиенты из репозитория.</returns>
    Task<ClientEntity[]> Get(CancellationToken cancellationToken);

    /// <summary>
    /// Возвращает клиента из репозитория.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Клиент.</returns>
    Task<ClientEntity> Get(int id, CancellationToken cancellationToken);
    
    /// <summary>
    /// Возвращает созданного клиента в репозитория.
    /// </summary>
    /// <param name="clientEntity">Клиент БД.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Клиент.</returns>
    Task<ClientDto> Create(ClientEntity clientEntity, CancellationToken cancellationToken);
    
    /// <summary>
    /// Возвращает обновленного клиента.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="client">Данные о клиенте.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Клиент.</returns>
    Task<ClientDto> Update(int id, ClientDto client, CancellationToken cancellationToken);

    /// <summary>
    /// Возвращает флаг успешного удаления клиента.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Флаг успешного удаления.</returns>
    Task<bool> Delete(int id, CancellationToken cancellationToken);
}