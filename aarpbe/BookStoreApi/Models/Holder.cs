using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;
using AARP_BE.Utilities;

namespace AARP_BE.Models
{
    public class Holder : ModelBase
    {
        /// <summary>
        /// User identifer related of this Holder
        /// </summary>
        public string? UserId { get; set; }
        /// <summary>
        /// Record identifer for this Holder
        /// </summary>
        public string? RecordId { get; set; }
        /// <summary>
        /// Status of this Holder
        /// </summary>
        public GenericStatus Status { get; set; } = 0;
    }
}
