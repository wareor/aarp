// <snippet_UsingSystemTextJsonSerialization>
using System.Text.Json.Serialization;
// </snippet_UsingSystemTextJsonSerialization>
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AARP_BE.Models;

public class PettyCash : ModelBase
{
    /// <summary>
    /// List of movements in and out of this entity, used as an accounting log of movements that lead to the Total property
    /// </summary>
    public IList<MoneyTransaction>? MoneyTransaction { get; set; }

    /// <summary>
    /// Total amount currently stored on the Petty cash
    /// </summary>
    public double? Total
    {
        get
        {
            return MoneyTransaction?.Select(x => x.Total).Sum() - MoneyTransaction?.Select(x => x.Total).Sum();
        }
    }

    /// <summary>
    /// List of logs with the user's actions performed on this entity
    /// </summary>
    public IList<string>? RecordId { get; set; }

}
