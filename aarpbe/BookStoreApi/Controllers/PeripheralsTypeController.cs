using AARP_BE.Models;
using AARP_BE.Services;
using Microsoft.AspNetCore.Mvc;


namespace AARP_BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeripheralsTypeController : ControllerBase
    {
        private readonly PeripheralsTypeService _servicesPeripheralsType;

        public PeripheralsTypeController(PeripheralsTypeService peripheralsTypeService) =>
            _servicesPeripheralsType = peripheralsTypeService;

        [HttpGet]
        public async Task<List<PeripheralsType>> Get() =>
            await _servicesPeripheralsType.GetAsync();

        [HttpGet("{ id:length(24)}")]
        public async Task<ActionResult<PeripheralsType>> Get(string id)
        {
            var peripheralsType = await _servicesPeripheralsType.GetAsync(id);

            if (peripheralsType is null)
            {
                return NotFound();
            }

            return peripheralsType;
        }

        [HttpPost]
        public async Task<IActionResult> Post(PeripheralsType newPeripheralsType)
        {
            await _servicesPeripheralsType.CreateAsync(newPeripheralsType);

            return CreatedAtAction(nameof(Get), new { id = newPeripheralsType.Id }, newPeripheralsType);
        }

        [HttpPut("{ id:length(24)}")]
        public async Task<IActionResult> Update(string id, PeripheralsType updatedPeripheralsType)
        {
            var peripheralsType = await _servicesPeripheralsType.GetAsync(id);

            if (peripheralsType is null)
            {
                return NotFound();
            }

            updatedPeripheralsType.Id = peripheralsType.Id;

            await _servicesPeripheralsType.UpdateAsync(id, updatedPeripheralsType);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var peripheralsType = await _servicesPeripheralsType.GetAsync(id);

            if (peripheralsType is null)
            {
                return NotFound();
            }

            await _servicesPeripheralsType.RemoveAsync(id);

            return NoContent();
        }
    }
}