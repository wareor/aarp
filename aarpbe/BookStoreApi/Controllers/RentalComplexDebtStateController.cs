using AARP_BE.Models;
using AARP_BE.Services;
using Microsoft.AspNetCore.Mvc;


namespace AARP_BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RentalComplexDebtStateController : ControllerBase
    {
        private readonly RentalComplexDebtStateService _servicesRentalComplexDebtState;

        public RentalComplexDebtStateController(RentalComplexDebtStateService rentalComplexDebtStateService) =>
            _servicesRentalComplexDebtState = rentalComplexDebtStateService;

        [HttpGet]
        public async Task<List<RentalComplexDebtState>> Get() =>
            await _servicesRentalComplexDebtState.GetAsync();

        [HttpGet("{ id:length(24)}")]
        public async Task<ActionResult<RentalComplexDebtState>> Get(string id)
        {
            var rentalComplexDebtState = await _servicesRentalComplexDebtState.GetAsync(id);

            if (rentalComplexDebtState is null)
            {
                return NotFound();
            }

            return rentalComplexDebtState;
        }

        [HttpPost]
        public async Task<IActionResult> Post(RentalComplexDebtState newRentalComplexDebtState)
        {
            await _servicesRentalComplexDebtState.CreateAsync(newRentalComplexDebtState);

            return CreatedAtAction(nameof(Get), new { id = newRentalComplexDebtState.Id }, newRentalComplexDebtState);
        }

        [HttpPut("{ id:length(24)}")]
        public async Task<IActionResult> Update(string id, RentalComplexDebtState updatedRentalComplexDebtState)
        {
            var rentalComplexDebtState = await _servicesRentalComplexDebtState.GetAsync(id);

            if (rentalComplexDebtState is null)
            {
                return NotFound();
            }

            updatedRentalComplexDebtState.Id = rentalComplexDebtState.Id;

            await _servicesRentalComplexDebtState.UpdateAsync(id, updatedRentalComplexDebtState);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var rentalComplexDebtState = await _servicesRentalComplexDebtState.GetAsync(id);

            if (rentalComplexDebtState is null)
            {
                return NotFound();
            }

            await _servicesRentalComplexDebtState.RemoveAsync(id);

            return NoContent();
        }
    }
}