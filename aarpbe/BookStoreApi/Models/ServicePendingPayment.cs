namespace AARP_BE.Models
{
    public class ServicePendingPayment
    {
        public string ServiceName { get; set; } = null!;
        public decimal Amount { get; set; } = 0;
        public DateTime? PayDate { get; set; }
    }
}
