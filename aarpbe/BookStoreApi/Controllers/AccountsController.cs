using AARP_BE.Models;
using AARP_BE.Services;
using Microsoft.AspNetCore.Mvc;


namespace AARP_BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly AccountService _servicesAccount;

        public AccountController(AccountService accountService) =>
            _servicesAccount = accountService;

        [HttpGet]
        public async Task<List<Account>> Get() =>
            await _servicesAccount.GetAsync();

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Account>> Get(string id)
        {
            var book = await _servicesAccount.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Account newAccount)
        {
            await _servicesAccount.CreateAsync(newAccount);

            return CreatedAtAction(nameof(Get), new { id = newAccount.Id }, newAccount);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Account updatedAccount)
        {
            var book = await _servicesAccount.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            updatedAccount.Id = book.Id;

            await _servicesAccount.UpdateAsync(id, updatedAccount);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var book = await _servicesAccount.GetAsync(id);

            if (book is null)
            {
                return NotFound();
            }

            await _servicesAccount.RemoveAsync(id);

            return NoContent();
        }
    }
}
