using Microsoft.AspNetCore.Mvc;
using NetAngularList.Application;
using NetAngularList.Communication;

namespace NetAngularList.Controllers
{
    [ApiController]
    [Route("api/client")]
    public class ClientController : ControllerBase
    {
        private readonly IClientsService _clientsService;

        public ClientController(IClientsService clientsService)
        {
            _clientsService = clientsService;
        }

        [HttpGet]
        [Route("inService")]
        public async Task<IList<ClientInfoDto>> GetInServiceClients(CancellationToken token)
        {
            return await _clientsService.GetInServiceClientsAsync(token);
        }

        [HttpGet]
        [Route("inLine")]
        public async Task<IList<ClientInfoDto>> GetInLineClients(CancellationToken token)
        {
            return await _clientsService.GetInLineClientsAsync(token);
        }

        [HttpPost]
        [Route("add")]
        public async Task Add([FromQuery] string fullName, CancellationToken token)
        {
            await _clientsService.AddClientAsync(fullName, token);
        }

        [HttpPost]
        [Route("next")]
        public async Task Next(int numberInLine, CancellationToken token)
        {
            await _clientsService.NextClientAsync(numberInLine, token);
        }
    }
}