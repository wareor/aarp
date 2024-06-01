namespace AARP_BE.Models
{
    public class ResidencePendingPayment
    {
        public string ResidenceNumber { get; set; } = null!;
        public string ResidenceName { get; set; } = null!;
        public double Amount { get; set; } = 0;
    }
}
