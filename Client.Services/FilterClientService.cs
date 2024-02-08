using System.Threading;
using System.Threading.Tasks;
using Client.Contracts;
using WebApplication4.Controllers;

namespace Client.Services;

internal class FilterClientService :IFilterClientService
{
    private readonly IFilterClientRepository _filterClientRepository;
    private readonly IClientMapper _clientMapper;

    public FilterClientService(IFilterClientRepository filterClientRepository, IClientMapper clientMapper)
    {
        _filterClientRepository = filterClientRepository;
        _clientMapper = clientMapper;
    }

    /// <summary>
    /// Возвращает массив, отфильтрованных клиентов.
    /// </summary>
    /// <param name="str">Строка, по которой будет произведена фильтрация.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Возвращает массив отфильтрованных клиентов из БД.</returns>
    public async Task<FilterClientDto[]> GetFilterClient(string str, CancellationToken cancellationToken)
    {
        ClientDto[] clientDtos =
            await _filterClientRepository.GetFilterClient(str, cancellationToken);
        return _clientMapper.Create(clientDtos);
    }
}