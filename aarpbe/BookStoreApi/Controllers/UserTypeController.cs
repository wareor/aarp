using AARP_BE.Models;
using AARP_BE.Services;
using Microsoft.AspNetCore.Mvc;


namespace AARP_BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserTypeController : ControllerBase
    {
        private readonly UserTypeService _servicesUserType;

        public UserTypeController(UserTypeService userTypeService) =>
            _servicesUserType = userTypeService;

        [HttpGet]
        public async Task<List<UserType>> Get() =>
            await _servicesUserType.GetAsync();

        [HttpGet("{ id:length(24)}")]
        public async Task<ActionResult<UserType>> Get(string id)
        {
            var userType = await _servicesUserType.GetAsync(id);

            if (userType is null)
            {
                return NotFound();
            }

            return userType;
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserType newUserType)
        {
            await _servicesUserType.CreateAsync(newUserType);

            return CreatedAtAction(nameof(Get), new { id = newUserType.Id }, newUserType);
        }

        [HttpPut("{ id:length(24)}")]
        public async Task<IActionResult> Update(string id, UserType updatedUserType)
        {
            var userType = await _servicesUserType.GetAsync(id);

            if (userType is null)
            {
                return NotFound();
            }

            updatedUserType.Id = userType.Id;

            await _servicesUserType.UpdateAsync(id, updatedUserType);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var userType = await _servicesUserType.GetAsync(id);

            if (userType is null)
            {
                return NotFound();
            }

            await _servicesUserType.RemoveAsync(id);

            return NoContent();
        }
    }
}