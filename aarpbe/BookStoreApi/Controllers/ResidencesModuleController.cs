using AARP_BE.Models;
using AARP_BE.Services;
using Microsoft.AspNetCore.Mvc;

namespace AARP_BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ResidencesModuleController : ControllerBase
    {
        private readonly ResidencesModuleService _residencesModuleService;

        public ResidencesModuleController(ResidencesModuleService residencesModuleService)
        {

            this._residencesModuleService = residencesModuleService;
        }


        [HttpGet]
        public async Task<ActionResult<IList<Residence>>> GetResidencesView()
        {
            return Ok(await this._residencesModuleService.GetResidencesView());
        }
        [HttpGet("{search:length(24)}")]
        public async Task<ActionResult<IList<Residence>>> GetResidence(string search)
        {
            return Ok(await this._residencesModuleService.GetResidence(search));
        }

        [HttpPost]
        [Route("Residence")]
        public async Task<IActionResult> Post(Residence newResidence)
        {
            /*
                  Una residencia incluye los campos de
                * RentalUnit
             */
            await this._residencesModuleService.CreateResidence(newResidence);
            return Ok();
        }

        [HttpPut]

        public async Task<IActionResult> UpdateResidence(string id, Residence updatedResidence)
        {
            var residence = await _residencesModuleService.GetResidence(id);

            if (residence is null)
            {
                return NotFound();
            }
            await this._residencesModuleService.UpdateResidence(updatedResidence);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody]string id)
        {
            var residence = await this._residencesModuleService.GetResidence(id);

            if (residence is null)
            {
                return NotFound();
            }

            await this._residencesModuleService.DeleteResidence(id);

            return NoContent();
        }
    }
}




/*
 REST
POST =eliminar un registro=
    URL
    Body
    URL Query parameters htthttps://open.spotify.com/track/1omuLiHsrZNngTOHr2FF9U?si=e85ba2384f724f97
    Esta solo define la manera de definición de Web Methods y relación con los métodos de HTTP [POST,PUT,DELETE,GET]

RESTful
    URL
    Body
    URL Query parameters htthttps://open.spotify.com/track/1omuLiHsrZNngTOHr2FF9U?si=e85ba2384f724f97

 */