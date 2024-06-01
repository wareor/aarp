using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;
using AARP_BE.Utilities;

namespace AARP_BE.Models
{
    public class Discount : ModelBase
    {
        /// <summary>
        /// Name of this Discount
        /// </summary>
        [BsonElement("Discount")]
        [JsonPropertyName("Discount")]
        public string DiscountName { get; set; } = null!;
        /// <summary>
        /// Discount Type for this Discount
        /// </summary>
        public DiscountType DiscountType { get; set; } 
        /// <summary>
        /// Rentai Unit identifer tied to this discount
        /// </summary>
        public string RentalUnitId { get; set; } = null!;
        /// <summary>
        /// Amount Type of this Discount
        /// </summary>
        public AmountType AmountType { get; set; }
        /// <summary>
        /// Amount valid for this Discount
        /// </summary>
        public double Amount { get; set; } = 0;
        /// <summary>
        /// Record identifer to this Discount
        /// </summary>
        public string? RecordId { get; set; }
        /// <summary>
        /// State of this Discount
        /// </summary>
        public GenericStatus Status { get; set; } = 0; // enum tbd, generic to deactivate, activate, on hold, banned, so on
        /// <summary>
        /// Date in which this Discount is not valid anymore
        /// </summary>
        public DateTime? ExpirationDate { get; set; }
    }
}
