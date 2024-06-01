using AARP_BE.Models;
using AARP_BE.Services;
using Microsoft.AspNetCore.Mvc;


namespace AARP_BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly ClientService _servicesClient;

        public ClientController(ClientService clientService) =>
            _servicesClient = clientService;

        [HttpGet]
        public async Task<List<Client>> Get() =>
            await _servicesClient.GetAsync();

        [HttpGet("{ id:length(24)}")]
        public async Task<ActionResult<Client>> Get(string id)
        {
            var client = await _servicesClient.GetAsync(id);

            if (client is null)
            {
                return NotFound();
            }

            return client;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Client newClient)
        {
            await _servicesClient.CreateAsync(newClient);

            return CreatedAtAction(nameof(Get), new { id = newClient.Id }, newClient);
        }

        [HttpPut("{ id:length(24)}")]
        public async Task<IActionResult> Update(string id, Client updatedClient)
        {
            var client = await _servicesClient.GetAsync(id);

            if (client is null)
            {
                return NotFound();
            }

            updatedClient.Id = client.Id;

            await _servicesClient.UpdateAsync(id, updatedClient);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var client = await _servicesClient.GetAsync(id);

            if (client is null)
            {
                return NotFound();
            }

            await _servicesClient.RemoveAsync(id);

            return NoContent();
        }
    }
}