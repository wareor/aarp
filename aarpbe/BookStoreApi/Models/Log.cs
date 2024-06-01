// <snippet_UsingSystemTextJsonSerialization>
using System.Text.Json.Serialization;
using AARP_BE.Utilities;
// </snippet_UsingSystemTextJsonSerialization>
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AARP_BE.Models;

public class Log : ModelBase
{
    /// <summary>
    /// Main message for this Log registry
    /// </summary>
    public string? Message { get; set; }
    /// <summary>
    /// Details of this event log, like large information or stacktrace
    /// </summary>
    public string? Details { get; set; }
    /// <summary>
    /// User Identifer that is in session on this event log or system user identifer for unatender process 
    /// </summary>
    public string? UserId { get; set; }
    /// <summary>
    /// Origin address from where this event log was originated
    /// </summary>
    public string? Address { get; set; }
    /// <summary>
    /// Operation description or name that this event log was created
    /// </summary>
    public string? Operation { get; set; }
    /// <summary>
    /// Error code or description belong to this event log
    /// </summary>
    public string? Error { get; set; }
    /// <summary>
    /// Details of this error, like large information or stacktrace
    /// </summary>
    public string? ErrorDetails { get; set; }

}
