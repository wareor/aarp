using System.Text.Json.Serialization;
using AARP_BE.Utilities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AARP_BE.Models
{
    public class RentalComplexDebtState : ModelBase
    {
        /// <summary>
        /// It's a reference to identify the deb for RentalComplex
        /// </summary>
        // <snippet_RentalComplexDebtStateName>
        [BsonElement("Name")]
        [JsonPropertyName("Name")]
        public string RentalComplexDebtStateName { get; set; } = null!;
        // </snippet_RentalComplexDebtStateName>
        /// <summary>
        /// Record identifier to RentalComplex
        /// </summary>
        public string RentalComplexId { get; set; } = null!;
        /// <summary>
        /// Total quantity for Rental Complex debt
        /// </summary>
        public double TotalOwed { get; set; } = 0;
        /// <summary>
        /// Record identifier RentalComplex did the paid
        /// </summary>
        public string? BillMethodId { get; set; }
        /// <summary>
        /// List of Rental Unit Debt State o each Rental Unit on the Rental Complex that owes to pay something or debt something to the administration
        /// </summary>
        public IList<RentalUnitDebtState>? RentalUnitDebtStates { get; set; }
        /// <summary>
        /// Status of the payment transaction for Rental Complex
        /// </summary>
        public GenericStatusMoney Status { get; set; } = 0;
    }
}
