using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;
using AARP_BE.Utilities;

namespace AARP_BE.Models
{
    /// <summary>
    /// This entity represents the owner of a rental unit
    /// Note: at this point this entity is non critial for the businness execution.
    /// </summary>
    public class Owner : ModelBase
    {
        /// <summary>
        /// User that owns the property
        /// </summary>
        public string? UserId { get; set; }

        /// <summary>
        /// List of logs with the user's actions performed on this entity
        /// </summary>
        public IList<string>? RecordId { get; set; }


        /// <summary>
        /// Reflects the current state of this entity's record
        /// </summary>
        public GenericStatus Status { get; set; } = 0;
    }
}
