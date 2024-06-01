using System.Text.Json.Serialization;
using AARP_BE.Utilities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AARP_BE.Models
{
    /// <summary>
    /// This entity represents the money to be paid for a service on a set time period
    /// that is to say, secirity on the complex is a service that has to be paid on the 
    /// time period set by the service.
    /// </summary>
    public class OwedDetail : ModelBase
    {
        /// <summary>
        /// References the service that is due to be paid
        /// </summary>
        public string? ServiceId { get; set; }

        /// <summary>
        /// Total due to be paid of the related service for this period
        /// </summary>
        public double Amount { get; set; } = 0;

        /// <summary>
        /// Reflects the current state of this entity's record
        /// </summary>
        public OwedDetailStatus Status { get; set; } = 0;
    }
}
