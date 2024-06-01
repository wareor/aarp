using AARP_BE.Models;
using AARP_BE.Services;
using Microsoft.AspNetCore.Mvc;


namespace AARP_BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeripheralController : ControllerBase
    {
        private readonly PeripheralService _servicesPeripheral;

        public PeripheralController(PeripheralService peripheralService) =>
            _servicesPeripheral = peripheralService;

        [HttpGet]
        public async Task<List<Peripheral>> Get() =>
            await _servicesPeripheral.GetAsync();

        [HttpGet("{ id:length(24)}")]
        public async Task<ActionResult<Peripheral>> Get(string id)
        {
            var peripheral = await _servicesPeripheral.GetAsync(id);

            if (peripheral is null)
            {
                return NotFound();
            }

            return peripheral;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Peripheral newPeripheral)
        {
            await _servicesPeripheral.CreateAsync(newPeripheral);

            return CreatedAtAction(nameof(Get), new { id = newPeripheral.Id }, newPeripheral);
        }

        [HttpPut("{ id:length(24)}")]
        public async Task<IActionResult> Update(string id, Peripheral updatedPeripheral)
        {
            var peripheral = await _servicesPeripheral.GetAsync(id);

            if (peripheral is null)
            {
                return NotFound();
            }

            updatedPeripheral.Id = peripheral.Id;

            await _servicesPeripheral.UpdateAsync(id, updatedPeripheral);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var peripheral = await _servicesPeripheral.GetAsync(id);

            if (peripheral is null)
            {
                return NotFound();
            }

            await _servicesPeripheral.RemoveAsync(id);

            return NoContent();
        }
    }
}