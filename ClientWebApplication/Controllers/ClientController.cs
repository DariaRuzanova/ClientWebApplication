using Client.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication4.Controllers;
/// <summary>
/// Входная точка для работы с клиентами.
/// </summary>
[Route("api/[controller]")]
public class ClientController : ControllerBase

{
    private readonly IClientService _clientService;

    public ClientController(IClientService clientService)
    {
        _clientService = clientService;
    }
    /// <summary>
    /// Возвращает массив клиентов.
    /// </summary>
    /// <returns>Массив клиентов.</returns>
    [HttpGet]
    public Task<ClientDto[]> Get()
    {
        return _clientService.Get(HttpContext.RequestAborted);
    }

    /// <summary>
    /// Возвращает клиента по id.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <returns>Клиент.</returns>
    [HttpGet("{id}")]
    public Task<ClientDto> Get(int id)
    {
        return _clientService.Get(id,HttpContext.RequestAborted);
    }

    /// <summary>
    /// Возвращает созданного клиента.
    /// </summary>
    /// <param name="request">Запрос на создание клиента.</param>
    /// <returns>Клиент.</returns>
    [HttpPost]
    public Task<ClientDto> Create([FromBody]ClientDto request)
    {
        return _clientService.Create(request,HttpContext.RequestAborted);
    }

    /// <summary>
    /// Возвращаем обновленного клиента.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="request">Запрос на обновление клиента.</param>
    /// <returns>Клиент.</returns>
    [HttpPut("{id}")] //сокращенная зспись URL: api/client/id
    public Task<ClientDto> Update(int id, [FromBody]ClientDto request)
    {
        return _clientService.Update(id, request, HttpContext.RequestAborted);
    }

    /// <summary>
    /// Возвращаем флаг успешного удаления.
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <returns>Флаг успешного удаления.</returns>
    [HttpDelete("{id}")]
    public Task<bool> Delete(int id)
    {
        return _clientService.Delete(id, HttpContext.RequestAborted);
    }
}

