using AARP_BE.Models;
using AARP_BE.Services;
using Microsoft.AspNetCore.Mvc;


namespace AARP_BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppPaymentController : ControllerBase
    {
        private readonly AppPaymentService _servicesAppPayment;

        public AppPaymentController(AppPaymentService appPaymentService) =>
            _servicesAppPayment = appPaymentService;

        [HttpGet]
        public async Task<List<AppPayment>> Get() =>
            await _servicesAppPayment.GetAsync();

        [HttpGet("{ id:length(24)}")]
        public async Task<ActionResult<AppPayment>> Get(string id)
        {
            var appPayment = await _servicesAppPayment.GetAsync(id);

            if (appPayment is null)
            {
                return NotFound();
            }

            return appPayment;
        }

        [HttpPost]
        public async Task<IActionResult> Post(AppPayment newAppPayment)
        {
            await _servicesAppPayment.CreateAsync(newAppPayment);

            return CreatedAtAction(nameof(Get), new { id = newAppPayment.Id }, newAppPayment);
        }

        [HttpPut("{ id:length(24)}")]
        public async Task<IActionResult> Update(string id, AppPayment updatedAppPayment)
        {
            var appPayment = await _servicesAppPayment.GetAsync(id);

            if (appPayment is null)
            {
                return NotFound();
            }

            updatedAppPayment.Id = appPayment.Id;

            await _servicesAppPayment.UpdateAsync(id, updatedAppPayment);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var appPayment = await _servicesAppPayment.GetAsync(id);

            if (appPayment is null)
            {
                return NotFound();
            }

            await _servicesAppPayment.RemoveAsync(id);

            return NoContent();
        }
    }
}