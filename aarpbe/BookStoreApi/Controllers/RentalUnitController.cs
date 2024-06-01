using AARP_BE.Models;
using AARP_BE.Services;
using Microsoft.AspNetCore.Mvc;

namespace AARP_BE.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RentalUnitsController : ControllerBase
{
    private readonly RentalUnitService _rentalUnitsService;

    public RentalUnitsController(RentalUnitService rentalUnitService) =>
        _rentalUnitsService = rentalUnitService;

    [HttpGet]
    public async Task<List<RentalUnit>> Get() =>
        await _rentalUnitsService.GetAsync();

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<RentalUnit>> Get(string id)
    {
        var rentalUnit = await _rentalUnitsService.GetAsync(id);

        if (rentalUnit is null)
        {
            return NotFound();
        }

        return rentalUnit;
    }

    [HttpPost]
    public async Task<IActionResult> Post(RentalUnit newRentalUnit)
    {
        await _rentalUnitsService.CreateAsync(newRentalUnit);

        return CreatedAtAction(nameof(Get), new { id = newRentalUnit.Id }, newRentalUnit);
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, RentalUnit updatedRentalUnit)
    {
        var book = await _rentalUnitsService.GetAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        updatedRentalUnit.Id = book.Id;

        await _rentalUnitsService.UpdateAsync(id, updatedRentalUnit);

        return NoContent();
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var book = await _rentalUnitsService.GetAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        await _rentalUnitsService.RemoveAsync(id);

        return NoContent();
    }
}
