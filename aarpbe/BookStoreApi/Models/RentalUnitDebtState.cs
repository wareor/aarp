using System.Text.Json.Serialization;
using AARP_BE.Utilities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AARP_BE.Models
{
    public class RentalUnitDebtState : ModelBase
    {
        /// <summary>
        /// It's a reference to identify the deb for RentalUnit
        /// </summary>
        // <snippet_RentalUnitDebtStateName>
        [BsonElement("Name")]
        [JsonPropertyName("Name")]
        public string RentalUnitDebtStateName { get; set; } = null!;
        // </snippet_RentalComplexDebtStateName>
        /// <summary>
        /// Record identifier to RentalComplexDebtState
        /// </summary>
        public string RentalComplexDebtStateId { get; set; } = null!;
        /// <summary>
        /// Total quantity for Rental Unit debt
        /// </summary>
        public double TotalOwed { get; set; } = 0;
        /// <summary>
        /// List of Rental Unit has
        /// </summary>
        public List<OwedDetail> OwedDetails { get; set; } = null!;
        /// <summary>
        /// Status of the payment transaction for Rental Unit
        /// </summary>
        public GenericStatusMoney Status { get; set; } = 0;
    }
}
