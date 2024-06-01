namespace AARP_BE.Models
{
    public class ResidencePaymentIndicator
    {
        /// <summary>
        /// Residences did all payements
        /// </summary>
        public int QuantityOfResidencesUpToDatePayment { get; set; } = 0;
        /// <summary>
        /// Residences have to do 1 payment at the month
        /// </summary>
        public int QuantityOfResidencesPendingPayment { get; set; } = 0;
        /// <summary>
        /// Residences have to do 2 payments or more
        /// </summary>
        public int QuantityOfResidencesDuePayment { get; set; } = 0;
    }
}
