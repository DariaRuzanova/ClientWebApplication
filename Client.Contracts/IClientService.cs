using System.Threading;
using System.Threading.Tasks;

namespace Client.Contracts;
/// <summary>
/// Сервис обработки клиентов.
/// </summary>
public interface IClientService
{
    /// <summary>
    /// Возвращает массив клиентов.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns></returns>
    Task<ClientDto[]> Get(CancellationToken cancellationToken);

    /// <summary>
    /// Возвращает клиента по id.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Клиент.</returns>
    Task<ClientDto> Get(int id, CancellationToken cancellationToken);

    /// <summary>
    /// Возвращает созданного клиента.
    /// </summary>
    /// <param name="client">Данные о клиенте.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Клиент.</returns>
    Task<ClientDto> Create(ClientDto client, CancellationToken cancellationToken);
    
    /// <summary>
    /// Возвращаем обновленного клиента.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="client">Данные о клиенте.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Клиент.</returns>
    Task<ClientDto> Update(int id, ClientDto client, CancellationToken cancellationToken);

    /// <summary>
    /// Возвращаем флаг успешного удаления.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Флаг успешного удаления.</returns>
    Task<bool> Delete(int id, CancellationToken cancellationToken);
}
