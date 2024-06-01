using AARP_BE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AARP_BE.Services
{
    public class AdminControlPanelModuleService
    {
        private IOptions<ResidenceAdministratorDatabaseSettings> residenceAdministratorDatabaseSettings;
        private ResidentService _residentService;
        private PettyCashService _pettyCashService;
        private RentalUnitService _rentalUnitService;
        //private RentalComplexService rentalComplexService;
        //private UserService _userService;
        //private RentalComplexDebtStateService _rentalComplexDebtStateService;
        //private ServiceService _serviceService;

        public AdminControlPanelModuleService(IOptions<ResidenceAdministratorDatabaseSettings> residenceAdministratorDatabaseSettings)
        {
            this.residenceAdministratorDatabaseSettings = residenceAdministratorDatabaseSettings;
            this._residentService = new ResidentService(residenceAdministratorDatabaseSettings);
            this._pettyCashService = new PettyCashService(residenceAdministratorDatabaseSettings);
            this._rentalUnitService = new RentalUnitService(residenceAdministratorDatabaseSettings);
        }

        public ActionResult<ResidentDebtStatusSummaryAndPettyCash> GetResidentDebtStatusSummaryAndPettyCashView()
        {
            //Resumen estado deuda residentes y caja chica
            var debtState = new ResidentDebtStatusSummaryAndPettyCash { PettyCashMoney = 11 , QuantityOfResidentsDuePayment = 1};
            return debtState;
            //throw new NotImplementedException();
        }

        public ActionResult<DebtStatusSummaryAndServicesPayment> GetDebtStatusSummaryAndServicesPaymentView()
        {
            //Resumen estado deuda y pago de servicios
            var debtStatusSummaryAndServicesPayment = new DebtStatusSummaryAndServicesPayment {};
            return debtStatusSummaryAndServicesPayment;
            //throw new NotImplementedException();
        }

        public ActionResult<IList<ResidencePendingPayment>> GetResidencesPendingPaymentView()
        {
            //Pendiente de revision
            //Lista simple de residencias pendientes de pago
            //var residencePendingPayment = this._rentalUnitService.GetAsync();
            throw new NotImplementedException();
        }

        public ActionResult<IList<ServicePendingPayment>> GetServicesPendingPaymentView()
        {
            //Lista simple de servicios pendiente de pago
            throw new NotImplementedException();
        }

        public ActionResult<ResidencePaymentIndicator> GetResidencePaymentIndicatorView()
        {
            //Gráfico de residencias con pago al corriente, pendiente y atrasado
            var residencePaymentIndicator = new ResidencePaymentIndicator {};
            return residencePaymentIndicator;
            //throw new NotImplementedException();
        }
    }
}
