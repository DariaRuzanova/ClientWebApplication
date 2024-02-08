using System.Threading;
using System.Threading.Tasks;
using Client.Contracts;

namespace Client.Services;

public interface IFilterClientRepository
{
    Task<ClientDto[]> GetFilterClient(string str, CancellationToken cancellationToken);
}