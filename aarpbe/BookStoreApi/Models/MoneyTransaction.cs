using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;
using AARP_BE.Utilities;

namespace AARP_BE.Models
{
    public class MoneyTransaction: ModelBase
    {
        /// <summary>
        /// Payment Identifer related to this Money Transaction
        /// </summary>
        public string? PaymentId { get; set; }
        /// <summary>
        /// Total amount of this money transaction
        /// </summary>
        public double Total { get; set; } = 0;
        /// <summary>
        /// Type of this Money Transaction
        /// </summary>
        public MoneyTransactionType MoneyTransactionType { get; set; } = 0;
        /// <summary>
        /// Specific status of this Money Transaction
        /// </summary>
        public MoneyTrasactionStatus Status { get; set; } = 0;
    }
}
