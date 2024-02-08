using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using Client.Contracts;
using Client.Services;

namespace Client.Repositories;

internal class FilterClientRepository : IFilterClientRepository
{
    private readonly IHttpClientFactory _httpClientFactory;

    public FilterClientRepository(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
    }

    /// <summary>
    /// Возвращаем массив отфильтрованных клиентов.
    /// </summary>
    /// <param name="str">Строка, ко которой будет произведена фильтрация.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Массив клиентов.</returns>
    public async Task<ClientDto[]> GetFilterClient(string str, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(str);
        HttpClient
            httpClient =
                _httpClientFactory.CreateClient(
                    nameof(FilterClientRepository)); //Создает и настраивает экземпляр HttpClient с использованием конфигурации, которая соответствует логическому имени, указанному в параметре name.
        ClientDto[]
            result = await httpClient.GetFromJsonAsync<ClientDto[]>("api/Client",
                cancellationToken); //Отправляем Get запрос и возвращаем десерилизованные объекты из JSON
        result = result.Where(x => x.Name.Contains(str, StringComparison.InvariantCultureIgnoreCase))
            .ToArray(); //Фильтрация
        return result;
    }
}