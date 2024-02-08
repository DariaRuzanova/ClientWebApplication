using System.Threading;
using System.Threading.Tasks;

namespace Client.Contracts;

/// <summary>
/// Сервис репозитория фильтрованных клиентов.
/// </summary>
public interface IFilterClientRepository
{
    /// <summary>
    /// Возвращает массив клиентов.
    /// </summary>
    /// <param name="str">Строка, по которой производится фильтрация.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Массив клиентов.</returns>
    Task<ClientDto[]> GetFilterClient(string str, CancellationToken cancellationToken);
}