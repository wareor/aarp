using AARP_BE.Models;
using AARP_BE.Services;
using Microsoft.AspNetCore.Mvc;


namespace AARP_BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RentalUnitDebtStateController : ControllerBase
    {
        private readonly RentalUnitDebtStateService _servicesRentalUnitDebtState;

        public RentalUnitDebtStateController(RentalUnitDebtStateService rentalUnitDebtStateService) =>
            _servicesRentalUnitDebtState = rentalUnitDebtStateService;

        [HttpGet]
        public async Task<List<RentalUnitDebtState>> Get() =>
            await _servicesRentalUnitDebtState.GetAsync();

        [HttpGet("{ id:length(24)}")]
        public async Task<ActionResult<RentalUnitDebtState>> Get(string id)
        {
            var rentalUnitDebtState = await _servicesRentalUnitDebtState.GetAsync(id);

            if (rentalUnitDebtState is null)
            {
                return NotFound();
            }

            return rentalUnitDebtState;
        }

        [HttpPost]
        public async Task<IActionResult> Post(RentalUnitDebtState newRentalUnitDebtState)
        {
            await _servicesRentalUnitDebtState.CreateAsync(newRentalUnitDebtState);

            return CreatedAtAction(nameof(Get), new { id = newRentalUnitDebtState.Id }, newRentalUnitDebtState);
        }

        [HttpPut("{ id:length(24)}")]
        public async Task<IActionResult> Update(string id, RentalUnitDebtState updatedRentalUnitDebtState)
        {
            var rentalUnitDebtState = await _servicesRentalUnitDebtState.GetAsync(id);

            if (rentalUnitDebtState is null)
            {
                return NotFound();
            }

            updatedRentalUnitDebtState.Id = rentalUnitDebtState.Id;

            await _servicesRentalUnitDebtState.UpdateAsync(id, updatedRentalUnitDebtState);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var rentalUnitDebtState = await _servicesRentalUnitDebtState.GetAsync(id);

            if (rentalUnitDebtState is null)
            {
                return NotFound();
            }

            await _servicesRentalUnitDebtState.RemoveAsync(id);

            return NoContent();
        }
    }
}