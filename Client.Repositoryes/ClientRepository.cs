using System.Collections.Concurrent;

namespace Client.Repositories;

internal class ClientRepository : IClientRepository
{
    private static readonly ConcurrentDictionary<int, ClientEntity> Context = new();
    private static int IdMax = 1;

    /// <summary>
    /// Возвращает массив клиентов из репозитория.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Массив клиентов.</returns>
    public Task<ClientEntity[]> Get(CancellationToken cancellationToken)
    {
        List<ClientEntity> clientEntities = new List<ClientEntity>();
        foreach (var clientEntity in Context)
        {
            clientEntities.Add(clientEntity.Value);
        }

        return Task.FromResult(clientEntities.ToArray());
    }

    /// <summary>
    /// Возвращает клиента.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Клиент.</returns>
    public Task<ClientEntity?> Get(int id, CancellationToken cancellationToken)
    {
        if (!Context.TryGetValue(id, out var clientEntity))
        {
            Task.FromResult(default(ClientEntity));
        }

        return Task.FromResult(clientEntity);
    }

    /// <summary>
    /// Возвращает созданного клиента.
    /// </summary>
    /// <param name="clientEntity">Данные о клиенте.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Клиент.</returns>
    public Task<ClientEntity> Create(ClientEntity clientEntity, CancellationToken cancellationToken)
    {
        int id = Interlocked.Increment(ref IdMax);
        clientEntity.id = id;
        Context.TryAdd(id, clientEntity);
        return Task.FromResult(clientEntity);
    }

    /// <summary>
    /// Возвращает обновленного клиента.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="clientEntity">Данные о клиенте.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns></returns>
    public Task<ClientEntity> Update(int id, ClientEntity clientEntity, CancellationToken cancellationToken)
    {
        if (Context.TryGetValue(id, out var clientEntityExisting))
        {
            if (Context.TryUpdate(id, clientEntity, clientEntityExisting)) ;
        }

        return Task.FromResult(clientEntity);
    }

    /// <summary>
    /// Флаг успешного удаления клиента.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Флаг успешного удаления.</returns>
    public Task<bool> Delete(int id, CancellationToken cancellationToken)
    {
        Context.TryRemove(id, out _);
        return Task.FromResult(true);
    }
}