using AARP_BE.Models;
using AARP_BE.Services;
using Microsoft.AspNetCore.Mvc;


namespace AARP_BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RentalUnitPaymentController : ControllerBase
    {
        private readonly RentalUnitPaymentService _servicesRentalUnitPayment;

        public RentalUnitPaymentController(RentalUnitPaymentService rentalUnitPaymentService) =>
            _servicesRentalUnitPayment = rentalUnitPaymentService;

        [HttpGet]
        public async Task<List<RentalUnitPayment>> Get() =>
            await _servicesRentalUnitPayment.GetAsync();

        [HttpGet("{ id:length(24)}")]
        public async Task<ActionResult<RentalUnitPayment>> Get(string id)
        {
            var rentalUnitPayment = await _servicesRentalUnitPayment.GetAsync(id);

            if (rentalUnitPayment is null)
            {
                return NotFound();
            }

            return rentalUnitPayment;
        }

        [HttpPost]
        public async Task<IActionResult> Post(RentalUnitPayment newRentalUnitPayment)
        {
            await _servicesRentalUnitPayment.CreateAsync(newRentalUnitPayment);

            return CreatedAtAction(nameof(Get), new { id = newRentalUnitPayment.Id }, newRentalUnitPayment);
        }

        [HttpPut("{ id:length(24)}")]
        public async Task<IActionResult> Update(string id, RentalUnitPayment updatedRentalUnitPayment)
        {
            var rentalUnitPayment = await _servicesRentalUnitPayment.GetAsync(id);

            if (rentalUnitPayment is null)
            {
                return NotFound();
            }

            updatedRentalUnitPayment.Id = rentalUnitPayment.Id;

            await _servicesRentalUnitPayment.UpdateAsync(id, updatedRentalUnitPayment);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var rentalUnitPayment = await _servicesRentalUnitPayment.GetAsync(id);

            if (rentalUnitPayment is null)
            {
                return NotFound();
            }

            await _servicesRentalUnitPayment.RemoveAsync(id);

            return NoContent();
        }
    }
}