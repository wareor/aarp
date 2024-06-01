using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;
using AARP_BE.Utilities;

namespace AARP_BE.Models
{
    public class Resident : ModelBase
    {
        /// <summary>
        /// Record identifier to User
        /// </summary>
        public string? UserId { get; set; }
        /// <summary>
        /// Record identifier to Record
        /// </summary>
        public string? RecordId { get; set; }
        /// <summary>
        /// Status of the resident
        /// </summary>
        public GenericStatus Status { get; set; } = 0;
    }
}
