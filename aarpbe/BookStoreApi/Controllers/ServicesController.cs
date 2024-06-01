using AARP_BE.Models;
using AARP_BE.Services;
using Microsoft.AspNetCore.Mvc;


namespace AARP_BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicesController : ControllerBase
    {
        private readonly ServiceService _servicesService;

        public ServicesController(ServiceService servicesService) =>
            _servicesService = servicesService;

        [HttpGet]
        public async Task<List<Account>> Get() =>
            await _servicesService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Account>> Get(string id)
        {
            var book = await _servicesService.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Account newService)
        {
            await _servicesService.CreateAsync(newService);

            return CreatedAtAction(nameof(Get), new { id = newService.Id }, newService);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Account updatedService)
        {
            var book = await _servicesService.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            updatedService.Id = book.Id;

            await _servicesService.UpdateAsync(id, updatedService);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var book = await _servicesService.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            await _servicesService.RemoveAsync(id);

            return NoContent();
        }
    }
}
