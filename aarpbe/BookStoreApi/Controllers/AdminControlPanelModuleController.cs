using AARP_BE.Models;
using AARP_BE.Services;
using Microsoft.AspNetCore.Mvc;

namespace AARP_BE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminControlPanelModuleController
    {
        private readonly AdminControlPanelModuleService _adminControlPanelModuleService;
        
        public AdminControlPanelModuleController(AdminControlPanelModuleService adminControlPanelModuleService) =>
            _adminControlPanelModuleService = adminControlPanelModuleService;

        [HttpGet]
        [Route("ResidentDebtStatusSummaryAndPettyCash")]
        public async Task<ActionResult<ResidentDebtStatusSummaryAndPettyCash>> GetResidentDebtStatusSummaryAndPettyCashView() {
            return this._adminControlPanelModuleService.GetResidentDebtStatusSummaryAndPettyCashView();
        }

        [HttpGet]
        [Route("DebtStatusSummaryAndServicesPayment")]
        public async Task<ActionResult<DebtStatusSummaryAndServicesPayment>> GetDebtStatusSummaryAndServicesPaymentView()
        {
            return this._adminControlPanelModuleService.GetDebtStatusSummaryAndServicesPaymentView();
        }

        [HttpGet]
        [Route("ResidencesPendingPayment")]
        public async Task<ActionResult<IList<ResidencePendingPayment>>> GetResidencesPendingPaymentView()
        {
            return this._adminControlPanelModuleService.GetResidencesPendingPaymentView();
        }

        [HttpGet]
        [Route("ServicesPendingPayment")]
        public async Task<ActionResult<IList<ServicePendingPayment>>> GetServicesPendingPaymentView()
        {
            return this._adminControlPanelModuleService.GetServicesPendingPaymentView();
        }

        [HttpGet]
        [Route("ResidencePaymentIndicator")]
        public async Task<ActionResult<ResidencePaymentIndicator>> GetResidencePaymentIndicatorView()
        {
            return this._adminControlPanelModuleService.GetResidencePaymentIndicatorView();
        }
    }
}
