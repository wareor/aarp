using AARP_BE.Models;
using AARP_BE.Services;
using Microsoft.AspNetCore.Mvc;


namespace AARP_BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LogController : ControllerBase
    {
        private readonly LogService _servicesLog;

        public LogController(LogService logService) =>
            _servicesLog = logService;

        [HttpGet]
        public async Task<List<Log>> Get() =>
            await _servicesLog.GetAsync();

        [HttpGet("{ id:length(24)}")]
        public async Task<ActionResult<Log>> Get(string id)
        {
            var log = await _servicesLog.GetAsync(id);

            if (log is null)
            {
                return NotFound();
            }

            return log;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Log newLog)
        {
            await _servicesLog.CreateAsync(newLog);

            return CreatedAtAction(nameof(Get), new { id = newLog.Id }, newLog);
        }

        [HttpPut("{ id:length(24)}")]
        public async Task<IActionResult> Update(string id, Log updatedLog)
        {
            var log = await _servicesLog.GetAsync(id);

            if (log is null)
            {
                return NotFound();
            }

            updatedLog.Id = log.Id;

            await _servicesLog.UpdateAsync(id, updatedLog);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var log = await _servicesLog.GetAsync(id);

            if (log is null)
            {
                return NotFound();
            }

            await _servicesLog.RemoveAsync(id);

            return NoContent();
        }
    }
}