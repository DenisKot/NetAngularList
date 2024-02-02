using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NetAngularList.Domain;

namespace NetAngularList.Data
{
    /// <summary>
    /// Represents a repository for managing <see cref="ClientInfo"/> entities.
    /// </summary>
    public interface IClientInfoRepository
    {
        /// <summary>
        /// Adds a new client to the database.
        /// </summary>
        /// <param name="client">The client to be added.</param>
        /// <param name="token">Cancellation token.</param>
        Task AddAsync(ClientInfo client, CancellationToken token);

        /// <summary>
        /// Updates an existing client in the database.
        /// </summary>
        /// <param name="updatedClient">The updated client information.</param>
        void Update(ClientInfo updatedClient);

        /// <summary>
        /// Retrieves a client by its ID from the database.
        /// </summary>
        /// <param name="id">The ID of the client to retrieve.</param>
        /// <param name="token">Cancellation token.</param>
        /// <returns>The client with the specified ID.</returns>
        Task<ClientInfo> GetByNumberInLineAsync(int id, CancellationToken token);

        /// <summary>
        /// Retrieves next client by its ID from the database.
        /// </summary>
        /// <param name="id">The ID of the client after what we should looking for.</param>
        /// <param name="token">Cancellation token.</param>
        /// <returns>The client with the specified ID.</returns>
        Task<ClientInfo> GetNextByNumberInLineAsync(int id, CancellationToken token);

        /// <summary>
        /// Retrieves a list of clients in service from the database.
        /// </summary>
        /// <param name="token">Cancellation token.</param>
        /// <returns>A list of clients in service.</returns>
        Task<List<ClientInfo>> GetInServiceClientsAsync(CancellationToken token);

        /// <summary>
        /// Retrieves a list of clients in line from the database.
        /// </summary>
        /// <param name="token">Cancellation token.</param>
        /// <returns>A list of clients in line.</returns>
        Task<List<ClientInfo>> GetInLineClientsAsync(CancellationToken token);

        /// <summary>
        /// Save changes to database
        /// </summary>
        /// <param name="token">Cancellation token.</param>
        Task SaveChangesAsync(CancellationToken token);
    }
}