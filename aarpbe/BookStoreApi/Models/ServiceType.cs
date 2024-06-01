using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;
using AARP_BE.Utilities;

namespace AARP_BE.Models
{
    public class ServiceType : ModelBase
    {
        /// <summary>
        /// Name of this Service Type
        /// </summary>
        [BsonElement("Name")]
        [JsonPropertyName("Name")]
        public string Name { get; set; } = null!;

    }
}
