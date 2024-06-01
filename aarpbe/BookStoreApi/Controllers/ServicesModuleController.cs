using AARP_BE.Models;
using AARP_BE.Services;
using Microsoft.AspNetCore.Mvc;

namespace AARP_BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicesModuleController : ControllerBase
    {
            private readonly ServicesModuleService _servicesModuleService;

            public ServicesModuleController(ServicesModuleService servicesModuleService)
            {

                this._servicesModuleService = servicesModuleService;
            }

            [HttpGet]
            public async Task<ActionResult<IList<Service>>> GetServicesView()
            {
                return Ok(await this._servicesModuleService.GetServicesView());
            }

            [HttpGet("{search:length(24)}")]
            public async Task<ActionResult<IList<Service>>> GetService(string search)
            {
                return Ok(await this._servicesModuleService.GetService(search));
            }

            [HttpPost]
            [Route("Service")]
            public async Task<IActionResult> Post(Service newService)
            {
                /*
                      Una residencia incluye los campos de
                    * RentalUnit
                 */
                await this._servicesModuleService.CreateService(newService);
                return Ok();
            }

            [HttpPut]
            public async Task<IActionResult> UpdateService(string id, Service updatedService)
            {
                var residence = await _servicesModuleService.GetService(id);

                if (residence is null)
                {
                    return NotFound();
                }
                await this._servicesModuleService.UpdateService(updatedService);

                return NoContent();
            }

            [HttpDelete]
            public async Task<IActionResult> Delete([FromBody] string id)
            {
                var residence = await this._servicesModuleService.GetService(id);

                if (residence is null)
                {
                    return NotFound();
                }

                await this._servicesModuleService.DeleteService(id);

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
