using AARP_BE.Models;
using AARP_BE.Services;
using Microsoft.AspNetCore.Mvc;


namespace AARP_BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OwedDetailController : ControllerBase
    {
        private readonly OwedDetailService _servicesOwedDetail;

        public OwedDetailController(OwedDetailService owedDetailService) =>
            _servicesOwedDetail = owedDetailService;

        [HttpGet]
        public async Task<List<OwedDetail>> Get() =>
            await _servicesOwedDetail.GetAsync();

        [HttpGet("{ id:length(24)}")]
        public async Task<ActionResult<OwedDetail>> Get(string id)
        {
            var owedDetail = await _servicesOwedDetail.GetAsync(id);

            if (owedDetail is null)
            {
                return NotFound();
            }

            return owedDetail;
        }

        [HttpPost]
        public async Task<IActionResult> Post(OwedDetail newOwedDetail)
        {
            await _servicesOwedDetail.CreateAsync(newOwedDetail);

            return CreatedAtAction(nameof(Get), new { id = newOwedDetail.Id }, newOwedDetail);
        }

        [HttpPut("{ id:length(24)}")]
        public async Task<IActionResult> Update(string id, OwedDetail updatedOwedDetail)
        {
            var owedDetail = await _servicesOwedDetail.GetAsync(id);

            if (owedDetail is null)
            {
                return NotFound();
            }

            updatedOwedDetail.Id = owedDetail.Id;

            await _servicesOwedDetail.UpdateAsync(id, updatedOwedDetail);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var owedDetail = await _servicesOwedDetail.GetAsync(id);

            if (owedDetail is null)
            {
                return NotFound();
            }

            await _servicesOwedDetail.RemoveAsync(id);

            return NoContent();
        }
    }
}