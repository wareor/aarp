using AARP_BE.Models;
using AARP_BE.Services;
using Microsoft.AspNetCore.Mvc;


namespace AARP_BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OwnerController : ControllerBase
    {
        private readonly OwnerService _servicesOwner;

        public OwnerController(OwnerService ownerService) =>
            _servicesOwner = ownerService;

        [HttpGet]
        public async Task<List<Owner>> Get() =>
            await _servicesOwner.GetAsync();

        [HttpGet("{ id:length(24)}")]
        public async Task<ActionResult<Owner>> Get(string id)
        {
            var owner = await _servicesOwner.GetAsync(id);

            if (owner is null)
            {
                return NotFound();
            }

            return owner;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Owner newOwner)
        {
            await _servicesOwner.CreateAsync(newOwner);

            return CreatedAtAction(nameof(Get), new { id = newOwner.Id }, newOwner);
        }

        [HttpPut("{ id:length(24)}")]
        public async Task<IActionResult> Update(string id, Owner updatedOwner)
        {
            var owner = await _servicesOwner.GetAsync(id);

            if (owner is null)
            {
                return NotFound();
            }

            updatedOwner.Id = owner.Id;

            await _servicesOwner.UpdateAsync(id, updatedOwner);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var owner = await _servicesOwner.GetAsync(id);

            if (owner is null)
            {
                return NotFound();
            }

            await _servicesOwner.RemoveAsync(id);

            return NoContent();
        }
    }
}