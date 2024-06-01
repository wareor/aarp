using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;


namespace AARP_BE.Models
{
    /// <summary>
    /// Stores the logs of all entities
    /// </summary>
    public class Record : ModelBase
    {
        /// <summary>
        /// Detailed description associated to this log record.
        /// </summary>
        public string? Comments { get; set; }
    }
}
