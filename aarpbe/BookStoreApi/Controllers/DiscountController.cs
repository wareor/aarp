using AARP_BE.Models;
using AARP_BE.Services;
using Microsoft.AspNetCore.Mvc;


namespace AARP_BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiscountController : ControllerBase
    {
        private readonly DiscountService _servicesDiscount;

        public DiscountController(DiscountService discountService) =>
            _servicesDiscount = discountService;

        [HttpGet]
        public async Task<List<Discount>> Get() =>
            await _servicesDiscount.GetAsync();

        [HttpGet("{ id:length(24)}")]
        public async Task<ActionResult<Discount>> Get(string id)
        {
            var discount = await _servicesDiscount.GetAsync(id);

            if (discount is null)
            {
                return NotFound();
            }

            return discount;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Discount newDiscount)
        {
            await _servicesDiscount.CreateAsync(newDiscount);

            return CreatedAtAction(nameof(Get), new { id = newDiscount.Id }, newDiscount);
        }

        [HttpPut("{ id:length(24)}")]
        public async Task<IActionResult> Update(string id, Discount updatedDiscount)
        {
            var discount = await _servicesDiscount.GetAsync(id);

            if (discount is null)
            {
                return NotFound();
            }

            updatedDiscount.Id = discount.Id;

            await _servicesDiscount.UpdateAsync(id, updatedDiscount);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var discount = await _servicesDiscount.GetAsync(id);

            if (discount is null)
            {
                return NotFound();
            }

            await _servicesDiscount.RemoveAsync(id);

            return NoContent();
        }
    }
}