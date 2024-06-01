// <snippet_UsingSystemTextJsonSerialization>
using System.Text.Json.Serialization;
using AARP_BE.Utilities;
// </snippet_UsingSystemTextJsonSerialization>
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AARP_BE.Models;

public class Client: ModelBase
{
    /// <summary>
    /// Name of this client/customer
    /// </summary>
    [BsonElement("Name")]
    [JsonPropertyName("Name")]
    public string ClientName { get; set; } = null!;
    /// <summary>
    /// Account identifer related to this Client
    /// </summary>
    public string AccountId { get; set; }
    /// <summary>
    /// Record identifer to this Client
    /// </summary>
    public string? RecordId { get; set; }
    /// <summary>
    /// Status of this Client
    /// </summary>
    public GenericStatus Status { get; set; } = 0;

}
