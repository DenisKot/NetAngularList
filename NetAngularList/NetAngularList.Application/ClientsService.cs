using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NetAngularList.Communication;
using NetAngularList.Data;
using NetAngularList.Domain;

namespace NetAngularList.Application
{
    public class ClientsService : IClientsService
    {
        private readonly IClientInfoRepository _repo;
        private readonly IMapperService _mapperService;

        public ClientsService(IClientInfoRepository repo, IMapperService mapperService)
        {
            _repo = repo;
            _mapperService = mapperService;
        }

        public async Task AddClientAsync(string fullName, CancellationToken token)
        {
            var client = new ClientInfo
            {
                State = ClientInfoState.InLine,
                FullName = fullName,
                CheckInTime = DateTimeOffset.Now
            };

            await _repo.AddAsync(client, token);
        }

        public async Task NextClientAsync(int numberInLine, CancellationToken token)
        {
            var client = await _repo.GetByNumberInLineAsync(numberInLine, token);
            if(client != null)
            {
                client.State = ClientInfoState.Finished;
            }

            var nextClient = await _repo.GetNextByNumberInLineAsync(numberInLine, token);
            if(nextClient != null)
            {
                nextClient.State = ClientInfoState.InService;
            }

            await _repo.SaveChangesAsync(token);
        }

        public async Task<IList<ClientInfoDto>> GetInServiceClientsAsync(CancellationToken token)
        {
            var clients = await _repo.GetInServiceClientsAsync(token);
            return _mapperService.Map<IList<ClientInfoDto>>(clients);
        }

        public async Task<IList<ClientInfoDto>> GetInLineClientsAsync(CancellationToken token)
        {
            var clients = await _repo.GetInLineClientsAsync(token);
            return _mapperService.Map<IList<ClientInfoDto>>(clients);
        }
    }
}