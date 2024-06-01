using MongoDB.Bson.Serialization.Attributes;
using AARP_BE.Utilities;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace AARP_BE.Models
{
    public class RentalUnitPayment : ModelBase
    {
        /// <summary>
        /// It's a reference to identify the RentalUnitPayment
        /// </summary>
        [BsonElement("Amount")]
        [JsonPropertyName("Amount")]
        public double Amount { get; set; } = 0;
        /// <summary>
        /// Record identifier to RentalUnit
        /// </summary>
        public string RentalUnitId { get; set; } = null!; // Rental Unit tied to the discount
        /// <summary>
        /// Record identifier to Currency RentalUnitPayment
        /// </summary>
        public string CurrencyId { get; set; } = null!; // mxn/usd/etc
        /// <summary>
        /// Record identifier to Frecuency RentalUnitPayment
        /// </summary>
        public string FrequencyId { get; set; } = null!; // frequency of the payment, to show on the bill of the user/tresury
        /// <summary>
        /// Last Date to RentalUnit has to pay
        /// </summary>
        public DateTime? ExpirationDate { get; set; }
        /// <summary>
        /// Status of the payment transaction for Rental Unit Payment
        /// </summary>
        public GenericStatusMoney Status { get; set; } = 0;
    }
}
