using AARP_BE.Models;
using AARP_BE.Services;
using Microsoft.AspNetCore.Mvc;


namespace AARP_BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoneyTransactionController : ControllerBase
    {
        private readonly MoneyTransactionService _servicesMoneyTransaction;

        public MoneyTransactionController(MoneyTransactionService moneyTransactionService) =>
            _servicesMoneyTransaction = moneyTransactionService;

        [HttpGet]
        public async Task<List<MoneyTransaction>> Get() =>
            await _servicesMoneyTransaction.GetAsync();

        [HttpGet("{ id:length(24)}")]
        public async Task<ActionResult<MoneyTransaction>> Get(string id)
        {
            var moneyTransaction = await _servicesMoneyTransaction.GetAsync(id);

            if (moneyTransaction is null)
            {
                return NotFound();
            }

            return moneyTransaction;
        }

        [HttpPost]
        public async Task<IActionResult> Post(MoneyTransaction newMoneyTransaction)
        {
            await _servicesMoneyTransaction.CreateAsync(newMoneyTransaction);

            return CreatedAtAction(nameof(Get), new { id = newMoneyTransaction.Id }, newMoneyTransaction);
        }

        [HttpPut("{ id:length(24)}")]
        public async Task<IActionResult> Update(string id, MoneyTransaction updatedMoneyTransaction)
        {
            var moneyTransaction = await _servicesMoneyTransaction.GetAsync(id);

            if (moneyTransaction is null)
            {
                return NotFound();
            }

            updatedMoneyTransaction.Id = moneyTransaction.Id;

            await _servicesMoneyTransaction.UpdateAsync(id, updatedMoneyTransaction);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var moneyTransaction = await _servicesMoneyTransaction.GetAsync(id);

            if (moneyTransaction is null)
            {
                return NotFound();
            }

            await _servicesMoneyTransaction.RemoveAsync(id);

            return NoContent();
        }
    }
}