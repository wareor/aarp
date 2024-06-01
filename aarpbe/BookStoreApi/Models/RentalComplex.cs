using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;
using AARP_BE.Utilities;

namespace AARP_BE.Models
{
    public class RentalComplex : ModelBase
    {
        /// <summary>
        /// Rental Complex Name or Alias
        /// </summary>
        [BsonElement("Name")]
        [JsonPropertyName("Name")]
        public string RentalComplexName { get; set; } = null!;
        /// <summary>
        /// List of Rental Unit Identifers that belong to this Rental Complex
        /// </summary>
        public IList<string>? RentalUnitId { get; set; }
        /// <summary>
        /// Record identifer to this Rental Complex
        /// </summary>
        public string? RecordId { get; set; }
        /// <summary>
        /// Address where this Rental Complex is Located
        /// </summary>
        public string? AddressId { get; set; }
        /// <summary>
        /// Status of this Rental Complex
        /// </summary>
        public GenericStatus Status { get; set; } = 0; // enum tbd, generic to deactivate, activate, on hold, so on
    }
}
