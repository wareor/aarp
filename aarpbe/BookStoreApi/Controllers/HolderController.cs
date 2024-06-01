using AARP_BE.Models;
using AARP_BE.Services;
using Microsoft.AspNetCore.Mvc;


namespace AARP_BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HolderController : ControllerBase
    {
        private readonly HolderService _servicesHolder;

        public HolderController(HolderService holderService) =>
            _servicesHolder = holderService;

        [HttpGet]
        public async Task<List<Holder>> Get() =>
            await _servicesHolder.GetAsync();

        [HttpGet("{ id:length(24)}")]
        public async Task<ActionResult<Holder>> Get(string id)
        {
            var holder = await _servicesHolder.GetAsync(id);

            if (holder is null)
            {
                return NotFound();
            }

            return holder;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Holder newHolder)
        {
            await _servicesHolder.CreateAsync(newHolder);

            return CreatedAtAction(nameof(Get), new { id = newHolder.Id }, newHolder);
        }

        [HttpPut("{ id:length(24)}")]
        public async Task<IActionResult> Update(string id, Holder updatedHolder)
        {
            var holder = await _servicesHolder.GetAsync(id);

            if (holder is null)
            {
                return NotFound();
            }

            updatedHolder.Id = holder.Id;

            await _servicesHolder.UpdateAsync(id, updatedHolder);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var holder = await _servicesHolder.GetAsync(id);

            if (holder is null)
            {
                return NotFound();
            }

            await _servicesHolder.RemoveAsync(id);

            return NoContent();
        }
    }
}