using Client.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication4.Controllers;
/// <summary>
/// Входная точка для фильтрации клиентов.
/// </summary>
[Route("api/filter/[controller]")]
public class FilterClientController : ControllerBase
{
    private readonly IFilterClientService _filterClientService;

    public FilterClientController(IFilterClientService filterClientService)
    {
        _filterClientService = filterClientService;
    }

    /// <summary>
    /// Возвращает массив клиентов.
    /// </summary>
    /// <param name="str">Строка, по которой будет произведена фильтрация.</param>
    /// <returns>Массив клиентов.</returns>
    [HttpGet]
    public Task<FilterClientDto[]> GetFilterClient(string str)
    {
        return _filterClientService.GetFilterClient(str,HttpContext.RequestAborted);
    }
}