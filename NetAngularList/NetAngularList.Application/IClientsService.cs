using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NetAngularList.Communication;

namespace NetAngularList.Application
{
    public interface IClientsService
    {
        Task AddClientAsync(string fullName, CancellationToken token);
        Task NextClientAsync(int numberInLine, CancellationToken token);
        Task<IList<ClientInfoDto>> GetInServiceClientsAsync(CancellationToken token);
        Task<IList<ClientInfoDto>> GetInLineClientsAsync(CancellationToken token);
    }
}