namespace AARP_BE.Models
{
    public class ResidentDebtStatusSummaryAndPettyCash
    {
        public double PettyCashMoney { get; set; } = 0;
        public double TotalResidentDebt { get; set; } = 0;
        /// <summary>
        /// Residents did all payements
        /// </summary>
        public int QuantityOfResidentsUpToDatePayment { get; set; } = 0;
        /// <summary>
        /// Residents have to do 1 payment at the month
        /// </summary>
        public int QuantityOfResidentsPendingPayment { get; set; } = 0;
        /// <summary>
        /// Residents have to do 2 payments or more
        /// </summary>
        public int QuantityOfResidentsDuePayment { get; set; } = 0;
    }
}
