// <snippet_UsingSystemTextJsonSerialization>
using System.Text.Json.Serialization;
using AARP_BE.Utilities;
// </snippet_UsingSystemTextJsonSerialization>
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AARP_BE.Models;

/// <summary>
/// This entity focuses on all the distinct types of peripherals that any given account may have
/// </summary>
public class PeripheralsType : ModelBase
{
    /// <summary>
    /// Provedes a short, easy to identify name for the user
    /// on the nature of the peripheral, an example could be "RemoteController"
    /// </summary>
    [BsonElement("Name")]
    [JsonPropertyName("Name")]
    public string PeripheralsTypeName { get; set; } = null!;
    // </snippet_PeripheralsTypeName>

    /// <summary>
    /// Provides an extended description on the nature of the peripheral
    /// An example could be "Remote controller used to open the front gate used for vehicles"
    /// </summary>
    public string? PeripheralsTypeDescription { get; set; }

    /// <summary>
    /// Reflects the current state of this entity's record
    /// </summary>
    public GenericStatus Status { get; set; } = 0;

    /// <summary>
    /// Provides a detailed description of the peripheral to be shown to the user 
    /// in order to facilitate identification of the peripheral
    /// </summary>
    public string? Description { get; set; }
}
