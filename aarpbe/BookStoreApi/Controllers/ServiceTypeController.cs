using AARP_BE.Models;
using AARP_BE.Services;
using Microsoft.AspNetCore.Mvc;


namespace AARP_BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceTypeController : ControllerBase
    {
        private readonly ServiceTypeService _servicesServiceType;

        public ServiceTypeController(ServiceTypeService serviceTypeService) =>
            _servicesServiceType = serviceTypeService;

        [HttpGet]
        public async Task<List<ServiceType>> Get() =>
            await _servicesServiceType.GetAsync();

        [HttpGet("{ id:length(24)}")]
        public async Task<ActionResult<ServiceType>> Get(string id)
        {
            var serviceType = await _servicesServiceType.GetAsync(id);

            if (serviceType is null)
            {
                return NotFound();
            }

            return serviceType;
        }

        [HttpPost]
        public async Task<IActionResult> Post(ServiceType newServiceType)
        {
            await _servicesServiceType.CreateAsync(newServiceType);

            return CreatedAtAction(nameof(Get), new { id = newServiceType.Id }, newServiceType);
        }

        [HttpPut("{ id:length(24)}")]
        public async Task<IActionResult> Update(string id, ServiceType updatedServiceType)
        {
            var serviceType = await _servicesServiceType.GetAsync(id);

            if (serviceType is null)
            {
                return NotFound();
            }

            updatedServiceType.Id = serviceType.Id;

            await _servicesServiceType.UpdateAsync(id, updatedServiceType);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var serviceType = await _servicesServiceType.GetAsync(id);

            if (serviceType is null)
            {
                return NotFound();
            }

            await _servicesServiceType.RemoveAsync(id);

            return NoContent();
        }
    }
}