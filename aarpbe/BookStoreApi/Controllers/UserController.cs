using AARP_BE.Models;
using AARP_BE.Services;
using Microsoft.AspNetCore.Mvc;


namespace AARP_BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _servicesUser;

        public UserController(UserService userService) =>
            _servicesUser = userService;

        [HttpGet]
        public async Task<List<User>> Get() =>
            await _servicesUser.GetAsync();

        [HttpGet("{ id:length(24)}")]
        public async Task<ActionResult<User>> Get(string id)
        {
            var user = await _servicesUser.GetAsync(id);

            if (user is null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost]
        public async Task<IActionResult> Post(User newUser)
        {
            await _servicesUser.CreateAsync(newUser);

            return CreatedAtAction(nameof(Get), new { id = newUser.Id }, newUser);
        }

        [HttpPut("{ id:length(24)}")]
        public async Task<IActionResult> Update(string id, User updatedUser)
        {
            var user = await _servicesUser.GetAsync(id);

            if (user is null)
            {
                return NotFound();
            }

            updatedUser.Id = user.Id;

            await _servicesUser.UpdateAsync(id, updatedUser);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _servicesUser.GetAsync(id);

            if (user is null)
            {
                return NotFound();
            }

            await _servicesUser.RemoveAsync(id);

            return NoContent();
        }
    }
}