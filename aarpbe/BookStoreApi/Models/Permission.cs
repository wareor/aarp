// <snippet_UsingSystemTextJsonSerialization>
using System.Text.Json.Serialization;
using AARP_BE.Utilities;
// </snippet_UsingSystemTextJsonSerialization>
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AARP_BE.Models;

/// <summary>
/// This entity provides permissions within the application
/// if a user role has the ability to make transactions, this is the place to create the permission to be assigned
/// </summary>
public class Permission : ModelBase
{
    /// <summary>
    /// Provides an easy, readable identifier that allows the identification of the permission within the application
    /// </summary>
    // <snippet_PermissionName>
    [BsonElement("Name")]
    [JsonPropertyName("Name")]
    public string PermissionName { get; set; } = null!;
    // </snippet_PermissionName>

    /// <summary>
    /// Provides a detailed description of the permission within the application
    /// </summary>
    public string? PermissionDescription { get; set; }

    /// <summary>
    /// Reflects the current state of this entity's record
    /// </summary>
    public GenericStatus Status { get; set; } = 0;

    //JALEF: considerar para los permisos el dividirlos por acción dentro de los módulos y relacionarlos a las acciones, que estarán limitadas en los métodos del servicio

}
