using System;
using System.Threading;
using System.Threading.Tasks;
using Client.Contracts;
using Client.Repositories;

namespace Client.Services;

internal class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;
    private readonly IClientMapper _clientMapper;

    public ClientService(IClientRepository clientRepository, IClientMapper clientMapper)
    {
        _clientRepository = clientRepository;
        _clientMapper = clientMapper;
    }
    /// <summary>
    /// Возвращает массив клиентов из БД.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Возвращает массив преобразованных клиентов из БД.</returns>
    public async Task<ClientDto[]> Get(CancellationToken cancellationToken)
    {
        ClientEntity[] clientEntities = await _clientRepository.Get(cancellationToken);
        return _clientMapper.Create(clientEntities);//преобразование из клиентов БД в клиентов веб-сервиса
    }

    /// <summary>
    /// Возвращает клиента из БД по id.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Возвращает преобразованного клиента из БД.</returns>
    public async Task<ClientDto> Get(int id, CancellationToken cancellationToken)
    {
        ClientEntity clientEntity = await _clientRepository.Get(id, cancellationToken);
        return _clientMapper.Create(clientEntity);
    }

    /// <summary>
    /// Возвращает созданного клиента в БД.
    /// </summary>
    /// <param name="client">Данные о клиенте.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Клиент.</returns>
    public async Task<ClientDto> Create(ClientDto client, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(client); //проверяет на null и может выбросить исключение
        ClientEntity clientEntity = _clientMapper.Create(client);
        ClientEntity entity = await _clientRepository.Create(clientEntity, cancellationToken);
        return _clientMapper.Create(entity);
    }

    /// <summary>
    /// Возвращает обновленного клиента в БД.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="client">Данные о клиенте.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Клиент.</returns>
    public async Task<ClientDto> Update(int id, ClientDto client, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(client);
        ClientEntity clientEntity = _clientMapper.Create(client);
        ClientEntity entity = await _clientRepository.Update(id, clientEntity, cancellationToken);
        return _clientMapper.Create(entity);
    }

    /// <summary>
    /// Возвращает флаг успешного удаления.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Флаг успешного удаления.</returns>
    public Task<bool> Delete(int id, CancellationToken cancellationToken)
    {
        return _clientRepository.Delete(id, cancellationToken);
    }
}