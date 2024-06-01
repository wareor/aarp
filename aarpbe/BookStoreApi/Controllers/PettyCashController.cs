using AARP_BE.Models;
using AARP_BE.Services;
using Microsoft.AspNetCore.Mvc;


namespace AARP_BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PettyCashController : ControllerBase
    {
        private readonly PettyCashService _servicesPettyCash;

        public PettyCashController(PettyCashService pettyCashService) =>
            _servicesPettyCash = pettyCashService;

        [HttpGet]
        public async Task<List<PettyCash>> Get() =>
            await _servicesPettyCash.GetAsync();

        [HttpGet("{ id:length(24)}")]
        public async Task<ActionResult<PettyCash>> Get(string id)
        {
            var pettyCash = await _servicesPettyCash.GetAsync(id);

            if (pettyCash is null)
            {
                return NotFound();
            }

            return pettyCash;
        }

        [HttpPost]
        public async Task<IActionResult> Post(PettyCash newPettyCash)
        {
            await _servicesPettyCash.CreateAsync(newPettyCash);

            return CreatedAtAction(nameof(Get), new { id = newPettyCash.Id }, newPettyCash);
        }

        [HttpPut("{ id:length(24)}")]
        public async Task<IActionResult> Update(string id, PettyCash updatedPettyCash)
        {
            var pettyCash = await _servicesPettyCash.GetAsync(id);

            if (pettyCash is null)
            {
                return NotFound();
            }

            updatedPettyCash.Id = pettyCash.Id;

            await _servicesPettyCash.UpdateAsync(id, updatedPettyCash);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var pettyCash = await _servicesPettyCash.GetAsync(id);

            if (pettyCash is null)
            {
                return NotFound();
            }

            await _servicesPettyCash.RemoveAsync(id);

            return NoContent();
        }
    }
}