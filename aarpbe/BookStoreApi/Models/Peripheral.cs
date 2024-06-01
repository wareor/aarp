// <snippet_UsingSystemTextJsonSerialization>
using System.Text.Json.Serialization;
using AARP_BE.Utilities;
using AARP_BE.Models;
// </snippet_UsingSystemTextJsonSerialization>
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AARP_BE.Models;

/// <summary>
/// Represents a single peripheral that exists or existed
/// </summary>
public class Peripheral : ModelBase
{
    /// <summary>
    /// Short, easy to identify and human readable name of the periperal
    /// </summary>
    [BsonElement("Name")]
    [JsonPropertyName("Name")]
    public string Name { get; set; } = null!;

    /// <summary>
    /// References the classification of this peripheral
    /// </summary>
    public string? PeripheralTypeId { get; set; }

    /// <summary>
    /// Amount to be paid to adquire this peripheral
    /// </summary>
    public double Cost { get; set; } = 0;

    /// <summary>
    /// List of logs with the user's actions performed on this entity
    /// </summary>
    public IList<string>? RecordId { get; set; }


    /// <summary>
    /// Reflects the current state of this entity's record
    /// </summary>
    public PeripheralStatus Status { get; set; } = 0; // será mejor crear un enumerable para esto también

}
