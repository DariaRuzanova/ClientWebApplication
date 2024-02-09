using System;
using System.Linq;
using Client.Contracts;
using Client.Repositories;
using WebApplication4.Controllers;
using ClientEntity = DataModel.ClientsSchema.Client;

namespace Client.Services;

internal class ClientMapper : IClientMapper
{
    /// <summary>
    /// Возвращает массив клиентов веб-сервиса.
    /// </summary>
    /// <param name="clientEntities">Массив клиентов репозитория.</param>
    /// <returns>Массив клиентов.</returns>
    public ClientDto[] Create(ClientEntity[] clientEntities)
    {
        ArgumentNullException.ThrowIfNull(clientEntities);
        return (from elem in clientEntities select Create(elem)).ToArray();
    }

    /// <summary>
    /// Возвращает клиента веб-сервиса.
    /// </summary>
    /// <param name="clientEntity">Данные клиента репозитория</param>
    /// <returns>Клиент.</returns>
    public ClientDto Create(ClientEntity clientEntity)
    {
        ArgumentNullException.ThrowIfNull(clientEntity);
        return new ClientDto()
               {
                   Id = clientEntity.Id,
                   Name = clientEntity.Name
               };
    }

    /// <summary>
    ///  Возвращает клиента репозитория.
    /// </summary>
    /// <param name="client">Данные клиента веб-сервиса.</param>
    /// <returns>Клиент.</returns>
    public ClientEntity Create(ClientDto client)
    {
        ArgumentNullException.ThrowIfNull(client);
        return new ClientEntity
               {
                   Id = client.Id,
                   Name = client.Name
               };
    }

    /// <summary>
    /// Возвращает массив отфильтрованных клиентов веб-сервиса.
    /// </summary>
    /// <param name="clientDtos">Массив клиентов веб-сервиса.</param>
    /// <returns>Массив отфильтрованных клиентов.</returns>
    public FilterClientDto[] Create(ClientDto[] clientDtos)
    {
        ArgumentNullException.ThrowIfNull(clientDtos);
        return clientDtos.Select(x => CreateFilterDto(x))
                         .ToArray();
    }

    /// <summary>
    /// Возвращает клиента веб-сервиса после фильтрации.
    /// </summary>
    /// <param name="clientDto">Клиент веб-сервиса.</param>
    /// <returns>Клиент.</returns>
    public FilterClientDto CreateFilterDto(ClientDto clientDto)
    {
        ArgumentNullException.ThrowIfNull(clientDto);
        return new FilterClientDto
               {
                   ClientId = clientDto.Id,
                   FullName = clientDto.Name
               };
    }
}