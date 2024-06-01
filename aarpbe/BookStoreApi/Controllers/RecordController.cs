using AARP_BE.Models;
using AARP_BE.Services;
using Microsoft.AspNetCore.Mvc;


namespace AARP_BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecordController : ControllerBase
    {
        private readonly RecordService _servicesRecord;

        public RecordController(RecordService recordService) =>
            _servicesRecord = recordService;

        [HttpGet]
        public async Task<List<Record>> Get() =>
            await _servicesRecord.GetAsync();

        [HttpGet("{ id:length(24)}")]
        public async Task<ActionResult<Record>> Get(string id)
        {
            var record = await _servicesRecord.GetAsync(id);

            if (record is null)
            {
                return NotFound();
            }

            return record;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Record newRecord)
        {
            await _servicesRecord.CreateAsync(newRecord);

            return CreatedAtAction(nameof(Get), new { id = newRecord.Id }, newRecord);
        }

        [HttpPut("{ id:length(24)}")]
        public async Task<IActionResult> Update(string id, Record updatedRecord)
        {
            var record = await _servicesRecord.GetAsync(id);

            if (record is null)
            {
                return NotFound();
            }

            updatedRecord.Id = record.Id;

            await _servicesRecord.UpdateAsync(id, updatedRecord);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var record = await _servicesRecord.GetAsync(id);

            if (record is null)
            {
                return NotFound();
            }

            await _servicesRecord.RemoveAsync(id);

            return NoContent();
        }
    }
}