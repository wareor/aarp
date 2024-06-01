namespace AARP_BE.Models
{
    public class DebtStatusSummaryAndServicesPayment
    {
        // Terminar de contruir el modelo
        public double TotalDebtToSuppliers { get; set; } = 0;
        public int OverduePaidServices { get; set; } = 0;
        public int PaidServices { get; set; } = 0;
    }
}
