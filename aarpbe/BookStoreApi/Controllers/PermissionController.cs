using AARP_BE.Models;
using AARP_BE.Services;
using Microsoft.AspNetCore.Mvc;


namespace AARP_BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PermissionController : ControllerBase
    {
        private readonly PermissionService _servicesPermission;

        public PermissionController(PermissionService permissionService) =>
            _servicesPermission = permissionService;

        [HttpGet]
        public async Task<List<Permission>> Get() =>
            await _servicesPermission.GetAsync();

        [HttpGet("{ id:length(24)}")]
        public async Task<ActionResult<Permission>> Get(string id)
        {
            var permission = await _servicesPermission.GetAsync(id);

            if (permission is null)
            {
                return NotFound();
            }

            return permission;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Permission newPermission)
        {
            await _servicesPermission.CreateAsync(newPermission);

            return CreatedAtAction(nameof(Get), new { id = newPermission.Id }, newPermission);
        }

        [HttpPut("{ id:length(24)}")]
        public async Task<IActionResult> Update(string id, Permission updatedPermission)
        {
            var permission = await _servicesPermission.GetAsync(id);

            if (permission is null)
            {
                return NotFound();
            }

            updatedPermission.Id = permission.Id;

            await _servicesPermission.UpdateAsync(id, updatedPermission);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var permission = await _servicesPermission.GetAsync(id);

            if (permission is null)
            {
                return NotFound();
            }

            await _servicesPermission.RemoveAsync(id);

            return NoContent();
        }
    }
}