using Client.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication4.Controllers;
/// <summary>
/// Входная точка для фильтрации клиентов.
/// </summary>
[Route("api/[controller]")]
public class FilterClientController : ControllerBase
{
    private readonly IFilterClientService _filterClientService;

    public FilterClientController(IFilterClientService filterClientService)
    {
        _filterClientService = filterClientService ?? throw new ArgumentNullException(nameof(filterClientService));
    }

    /// <summary>
    /// Возвращает массив отфильтрованных клиентов.
    /// </summary>
    /// <param name="str">Строка, по которой будет произведена фильтрация.</param>
    /// <returns>Массив клиентов.</returns>
    [HttpGet]
    public Task<FilterClientDto[]> GetFilterClient(string str)
    {
        ArgumentNullException.ThrowIfNull(str);
        return _filterClientService.GetFilterClient(str,HttpContext.RequestAborted);
    }
}