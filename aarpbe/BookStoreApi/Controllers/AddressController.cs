using AARP_BE.Models;
using AARP_BE.Services;
using Microsoft.AspNetCore.Mvc;


namespace AARP_BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly AddressService _addressService;

        public AddressController(AddressService addressService) =>
            _addressService = addressService;

        [HttpGet]
        public async Task<List<Address>> Get() =>
            await _addressService.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Address>> Get(string id)
        {
            var address = await _addressService.GetAsync(id);

            if (address is null)
            {
                return NotFound();
            }

            return address;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Address newaddress)
        {
            await _addressService.CreateAsync(newaddress);

            return CreatedAtAction(nameof(Get), new { id = newaddress.Id }, newaddress);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Address updatedAccount)
        {
            var address = await _addressService.GetAsync(id);

            if (address is null)
            {
                return NotFound();
            }

            updatedAccount.Id = address.Id;

            await _addressService.UpdateAsync(id, updatedAccount);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var address = await _addressService.GetAsync(id);

            if (address is null)
            {
                return NotFound();
            }

            await _addressService.RemoveAsync(id);

            return NoContent();
        }
    }
}
