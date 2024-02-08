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

    public async Task<ClientDto[]> GetFilterClient(string str, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(str);
        HttpClient httpClient = _httpClientFactory.CreateClient(nameof(FilterClientRepository));
        ClientDto[] result = await httpClient.GetFromJsonAsync<ClientDto[]>("api/Client", cancellationToken);
        result = result.Where(x => x.Name.Contains(str, StringComparison.InvariantCultureIgnoreCase)).ToArray();
        return result;
    }
}