using AARP_BE.Models;
using AARP_BE.Services;
using Microsoft.AspNetCore.Mvc;


namespace AARP_BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RentalComplexController : ControllerBase
    {
        private readonly RentalComplexService _servicesRentalComplex;

        public RentalComplexController(RentalComplexService rentalComplexService) =>
            _servicesRentalComplex = rentalComplexService;

        [HttpGet]
        public async Task<List<RentalComplex>> Get() =>
            await _servicesRentalComplex.GetAsync();

        [HttpGet("{ id:length(24)}")]
        public async Task<ActionResult<RentalComplex>> Get(string id)
        {
            var rentalComplex = await _servicesRentalComplex.GetAsync(id);

            if (rentalComplex is null)
            {
                return NotFound();
            }

            return rentalComplex;
        }

        [HttpPost]
        public async Task<IActionResult> Post(RentalComplex newRentalComplex)
        {
            await _servicesRentalComplex.CreateAsync(newRentalComplex);

            return CreatedAtAction(nameof(Get), new { id = newRentalComplex.Id }, newRentalComplex);
        }

        [HttpPut("{ id:length(24)}")]
        public async Task<IActionResult> Update(string id, RentalComplex updatedRentalComplex)
        {
            var rentalComplex = await _servicesRentalComplex.GetAsync(id);

            if (rentalComplex is null)
            {
                return NotFound();
            }

            updatedRentalComplex.Id = rentalComplex.Id;

            await _servicesRentalComplex.UpdateAsync(id, updatedRentalComplex);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var rentalComplex = await _servicesRentalComplex.GetAsync(id);

            if (rentalComplex is null)
            {
                return NotFound();
            }

            await _servicesRentalComplex.RemoveAsync(id);

            return NoContent();
        }
    }
}