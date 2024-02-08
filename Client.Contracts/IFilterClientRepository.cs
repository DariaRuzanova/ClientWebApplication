using Client.Contracts;

namespace Client.Services;

public interface IFilterClientRepository
{
    Task<ClientDto[]> GetFilterClient(string str, CancellationToken cancellationToken);
}