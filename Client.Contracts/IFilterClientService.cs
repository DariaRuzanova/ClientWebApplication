using WebApplication4.Controllers;

namespace Client.Contracts;

/// <summary>
/// Сервис фильтрации клиентов.
/// </summary>
public interface IFilterClientService
{
    /// <summary>
    /// Возвращает отфильтрованный массив клиентов.
    /// </summary>
    /// <param name="str">Строка, по которой будет произведена фильтрация.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Массив клиентов.</returns>
    public Task<FilterClientDto[]> GetFilterClient(string str, CancellationToken cancellationToken);
}



