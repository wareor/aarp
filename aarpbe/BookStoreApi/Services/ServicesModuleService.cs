using AARP_BE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AARP_BE.Services
{
    public class ServicesModuleService
    {
        private IOptions<ServiceAdministratorDatabaseSettings> _serviceAdministratorDatabaseSettings;
        private RentalUnitService _rentalUtinService;
        private AddressService _addressService;
        public ServicesModuleService(IOptions<ServiceAdministratorDatabaseSettings> serviceAdministratorDatabaseSettings)
        {
            this._serviceAdministratorDatabaseSettings = serviceAdministratorDatabaseSettings;
            this._rentalUtinService = new RentalUnitService(serviceAdministratorDatabaseSettings);
            this._addressService = new AddressService(serviceAdministratorDatabaseSettings);
        }

        public async Task<ActionResult<IList<Service>>> GetService(string search)
        {

            return null;
        }
        public async Task<ActionResult<IList<Service>>> GetServicesView()
        {

            return null;
        }

        public async Task<IActionResult> UpdateService(Service newResicence)
        {
            // Agregar creación de residencias con la lógica de negocios correspondiente.
            return null;
            //return this._rentalUtinService.CreateAsync(newResicence);
        }
        public async Task CreateService(Service newResicence)
        {
        }

        public async Task DeleteService(string id)
        {
        }
    }
}
