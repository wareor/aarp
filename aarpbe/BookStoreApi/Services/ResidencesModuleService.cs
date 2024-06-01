using AARP_BE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AARP_BE.Services
{
    public class ResidencesModuleService
    {
        private IOptions<ResidenceAdministratorDatabaseSettings> _residenceAdministratorDatabaseSettings;
        private RentalUnitService _rentalUtinService;
        private AddressService _addressService;
        private UserService _userService;
        private RentalComplexDebtStateService _rentalComplexDebtStateService;
        public ResidencesModuleService(IOptions<ResidenceAdministratorDatabaseSettings> residenceAdministratorDatabaseSettings)
        {
            this._residenceAdministratorDatabaseSettings = residenceAdministratorDatabaseSettings;
            this._rentalUtinService = new RentalUnitService(residenceAdministratorDatabaseSettings);
            this._addressService = new AddressService(residenceAdministratorDatabaseSettings);
            this._userService = new UserService(residenceAdministratorDatabaseSettings);
            this._rentalComplexDebtStateService = new RentalComplexDebtStateService(residenceAdministratorDatabaseSettings);
        }

        public async Task<ActionResult<IList<Residence>>> GetResidence(string search)
        {
            /*
             NombreResidencia
            NombreUsuarioHolder
            Status
            TotalDeuda
            EstadoDeuda
            Dirección             
             */
            //Agregar mapeo de un tipo de objeto a otro
            //return this._rentalUtinService.GetAsync();
            return null;
        }
        public async Task<ActionResult<IList<Residence>>> GetResidencesView()
        {
            /*
             NombreResidencia
            NombreUsuarioHolder
            Status
            TotalDeuda
            EstadoDeuda
            Dirección             
             */
            //Agregar mapeo de un tipo de objeto a otro
            //return this._rentalUtinService.GetAsync();
            return null;
        }

        public async Task<IActionResult> UpdateResidence(Residence newResicence)
        {
            // Agregar creación de residencias con la lógica de negocios correspondiente.
            return null;
            //return this._rentalUtinService.CreateAsync(newResicence);
        }
        public async Task<Residence> CreateResidence(Residence newResicence)
        {
            var address = await this._addressService.CreateAsync(newResicence.Address);
            newResicence.RentalUnit.AddressId = address.Id;
            var rentalUnit = await this._rentalUtinService.CreateAsync(newResicence.RentalUnit);
            newResicence.ResidenceName = address.SuiteNumber;
            var user = await this._userService.GetAsync(newResicence.RentalUnit.HolderId);
            newResicence.HolderName = user.Names;
            newResicence.Status = newResicence.RentalUnit.Status.ToString();
            var rentalUnitDebtState = await this._rentalComplexDebtStateService.GetRentalUnitDebtState(newResicence.RentalUnit.Id);
            //newResicence.TotalDebt = rentalUnitDebtState.

            return newResicence;

            // Agregar creación de residencias con la lógica de negocios correspondiente.
            //return resultCreateRentalUnit;
            //r
        }

        public async Task DeleteResidence(string id)
        {
            // agregar lógica para eliminar una residencia (para este y otros casos es necesario implementar las validaciones entre tentidades detallado en Nodas de desarrollo del documento de definición de mómulos)
            //await _pettyCashsCollection.DeleteOneAsync(x => x.Id == id);
        }
    }
}
