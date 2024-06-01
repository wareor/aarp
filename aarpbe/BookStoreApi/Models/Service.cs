using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;
using AARP_BE.Utilities;

namespace AARP_BE.Models
{
    public class Service : ModelBase
    {
        /// <summary>
        /// It's a reference to identify the Service
        /// </summary>
        // <snippet_ServiceName>
        [BsonElement("Name")]
        [JsonPropertyName("Name")]
        public string? ServiceName { get; set; }
        // </snippet_ResidenceName>
        /// <summary>
        /// Cost of the service per all the users have the service
        /// </summary>
        public double CommunityCost { get; set; } = 0;
        /// <summary>
        /// Cost of the service per user
        /// </summary>
        public double IndividualCost { get; set; } = 0;
        /// <summary>
        /// Recurrency of the service payment has
        /// </summary>
        public Recurrency? Recurrency { get; set; }
        /// <summary>
        /// Currency to calculate the amount of the service
        /// </summary>
        public Currency Currency { get; set; } = Currency.MXN;
        /// <summary>
        /// Type of the service has
        /// </summary>
        public string? ServiceTypeId { get; set; }
        /// <summary>
        /// Provider of the Service
        /// </summary>
        public string? Provider { get; set; }
        /// <summary>
        /// General Description to understand the Service
        /// </summary>
        public string? ServiceDescription { get; set; }
        /// <summary>
        /// Record identifier to Record
        /// </summary>
        public string? RecordId { get; set; }
        /// <summary>
        /// Status to identify the service
        /// </summary>
        public GenericStatus Status { get; set; } = 0;
    }
}
