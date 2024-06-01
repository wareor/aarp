using AARP_BE.Models;
using AARP_BE.Services;
using Microsoft.AspNetCore.Mvc;


namespace AARP_BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResidentController : ControllerBase
    {
        private readonly ResidentService _servicesResident;

        public ResidentController(ResidentService residentService) =>
            _servicesResident = residentService;

        [HttpGet]
        public async Task<List<Resident>> Get() =>
            await _servicesResident.GetAsync();

        [HttpGet("{ id:length(24)}")]
        public async Task<ActionResult<Resident>> Get(string id)
        {
            var resident = await _servicesResident.GetAsync(id);

            if (resident is null)
            {
                return NotFound();
            }

            return resident;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Resident newResident)
        {
            await _servicesResident.CreateAsync(newResident);

            return CreatedAtAction(nameof(Get), new { id = newResident.Id }, newResident);
        }

        [HttpPut("{ id:length(24)}")]
        public async Task<IActionResult> Update(string id, Resident updatedResident)
        {
            var resident = await _servicesResident.GetAsync(id);

            if (resident is null)
            {
                return NotFound();
            }

            updatedResident.Id = resident.Id;

            await _servicesResident.UpdateAsync(id, updatedResident);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var resident = await _servicesResident.GetAsync(id);

            if (resident is null)
            {
                return NotFound();
            }

            await _servicesResident.RemoveAsync(id);

            return NoContent();
        }
    }
}