using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataModel;
using LinqToDB;

namespace Client.Repositories;

internal class ClientRepository : IClientRepository
{
    private readonly ClientContextDb _clientContextDb;

    public ClientRepository(ClientContextDb clientContextDb)
    {
        _clientContextDb = clientContextDb ?? throw new ArgumentNullException(nameof(clientContextDb));
    }

    /// <summary>
    /// Возвращает массив клиентов из репозитория.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Массив клиентов.</returns>
    public  Task<ClientsSchema.Client[]> Get(CancellationToken cancellationToken)
    {
        return _clientContextDb.Clients.Clients.ToArrayAsync(token: cancellationToken);
    }

    /// <summary>
    /// Возвращает клиента.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Клиент.</returns>
    public  Task<ClientsSchema.Client> Get(int id, CancellationToken cancellationToken)
    {
        return _clientContextDb.Clients.Clients.SingleOrDefaultAsync(x => x.Id == id, token: cancellationToken);
    }

    /// <summary>
    /// Возвращает созданного клиента.
    /// </summary>
    /// <param name="clientEntity">Данные о клиенте.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Клиент.</returns>
    public async Task<ClientsSchema.Client> Create(ClientsSchema.Client clientEntity, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(clientEntity);
        int id = await _clientContextDb.InsertWithInt32IdentityAsync(clientEntity, token: cancellationToken);
        clientEntity.Id = id;
        return clientEntity;
    }

    /// <summary>
    /// Возвращает обновленного клиента.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="clientEntity">Данные о клиенте.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns></returns>
    public async Task<ClientsSchema.Client> Update(int id, ClientsSchema.Client clientEntity, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(clientEntity);
        int x = await _clientContextDb.Clients.Clients.UpdateAsync(t => t.Id == id,
                                                        c => new ClientsSchema.Client()
                                                             {
                                                                 Name = clientEntity.Name
                                                             },
                                                        token: cancellationToken);
        if (x == 0)
        {
            throw new InvalidOperationException("По переданному идентификатору id не найдена запись для обновления.");
        }
        return await Get(id, cancellationToken);
    }

    /// <summary>
    /// Флаг успешного удаления клиента.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Флаг успешного удаления.</returns>
    public async Task<bool> Delete(int id, CancellationToken cancellationToken)
    {
        int x = await _clientContextDb.Clients.Clients.DeleteAsync(x => x.Id == id, cancellationToken);
        return x != 0;
    }
}