using AARP_BE.Models;
using AARP_BE.Services;
using Microsoft.AspNetCore.Mvc;


namespace AARP_BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly PaymentService _servicesPayment;

        public PaymentController(PaymentService paymentService) =>
            _servicesPayment = paymentService;

        [HttpGet]
        public async Task<List<Payment>> Get() =>
            await _servicesPayment.GetAsync();

        [HttpGet("{ id:length(24)}")]
        public async Task<ActionResult<Payment>> Get(string id)
        {
            var payment = await _servicesPayment.GetAsync(id);

            if (payment is null)
            {
                return NotFound();
            }

            return payment;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Payment newPayment)
        {
            await _servicesPayment.CreateAsync(newPayment);

            return CreatedAtAction(nameof(Get), new { id = newPayment.Id }, newPayment);
        }

        [HttpPut("{ id:length(24)}")]
        public async Task<IActionResult> Update(string id, Payment updatedPayment)
        {
            var payment = await _servicesPayment.GetAsync(id);

            if (payment is null)
            {
                return NotFound();
            }

            updatedPayment.Id = payment.Id;

            await _servicesPayment.UpdateAsync(id, updatedPayment);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var payment = await _servicesPayment.GetAsync(id);

            if (payment is null)
            {
                return NotFound();
            }

            await _servicesPayment.RemoveAsync(id);

            return NoContent();
        }
    }
}