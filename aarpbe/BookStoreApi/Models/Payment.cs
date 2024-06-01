// <snippet_UsingSystemTextJsonSerialization>
using System.Text.Json.Serialization;
using AARP_BE.Utilities;
// </snippet_UsingSystemTextJsonSerialization>
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AARP_BE.Models;

/// <summary>
/// Payment done to the owners of the account
/// </summary>
public class Payment : ModelBase
{
    /// <summary>
    /// Description of was was paid to the account owners
    /// </summary>
    [BsonElement("Name")]
    [JsonPropertyName("Name")]
    public string Name { get; set; } = null!;

    /// <summary>
    /// Enum used to signal which payment type was used (credit, debit, cash, etc)
    /// </summary>
    public PaymentType? PaymentType { get; set; }
    /// <summary>
    /// Key or File name of evidence of payment
    /// </summary>
    public string? PaymentBill { get; set; } // considerar almacenar esto en un sistema de almacenamiento diferente en donde solo se guarde el key del archivo
    
    /// <summary>
    /// Amount paid to the administration of the Account
    /// </summary>
    public double Amount { get; set; } = 0;

    /// <summary>
    /// Type of currency to make this payment, example (USD, MXN)
    /// </summary>
    public string? Currency { get; set; }

    /// <summary>
    /// User that made the payment
    /// </summary>
    public string? UserId { get; set; }

    /// <summary>
    /// Current reference used as a proof of payment
    /// </summary>
    public string? ReferenceNumber { get; set; } //revisar mas adelante como se registrará la referencia

    /// <summary>
    /// List of logs with the user's actions performed on this entity
    /// </summary>
    public IList<string>? RecordId { get; set; }


    /// <summary>
    /// Reflects the current state of this entity's record
    /// </summary>
    public PaymentTypeStatus Status { get; set; } = 0;
}
