using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetAngularList.Domain;

namespace NetAngularList.Data
{
    /// <inheritdoc />
    public class ClientInfoRepository : IClientInfoRepository
    {
        private readonly AppDbContext _dbContext;

        public ClientInfoRepository(AppDbContext context)
        {
            _dbContext = context;
        }

        /// <inheritdoc />
        public async Task AddAsync(ClientInfo client, CancellationToken token)
        {
            await _dbContext.Clients.AddAsync(client, token);
            await _dbContext.SaveChangesAsync(token);
        }

        /// <inheritdoc />
        public void Update(ClientInfo updatedClient)
        {
            _dbContext.Attach(updatedClient);
        }

        /// <inheritdoc />
        public async Task<ClientInfo> GetByNumberInLineAsync(int id, CancellationToken token)
        {
            return await _dbContext.Clients.FindAsync(id, token);
        }

        /// <inheritdoc />
        public async Task<ClientInfo> GetNextByNumberInLineAsync(int id, CancellationToken token)
        {
            return await _dbContext.Clients
                .OrderBy(c => c.NumberInLine)
                .Where(c => c.State == 0)
                .FirstOrDefaultAsync(token);
        }

        /// <inheritdoc />
        public async Task<List<ClientInfo>> GetInServiceClientsAsync(CancellationToken token)
        {
            return await _dbContext.Clients
                .Where(c => c.State == ClientInfoState.InService)
                .ToListAsync(token);
        }

        /// <inheritdoc />
        public async Task<List<ClientInfo>> GetInLineClientsAsync(CancellationToken token)
        {
            return await _dbContext.Clients
                .Where(c => c.State == ClientInfoState.InLine)
                .ToListAsync(token);
        }

        /// <inheritdoc />
        public async Task SaveChangesAsync(CancellationToken token)
        {
            await _dbContext.SaveChangesAsync(token);
        }
    }
}