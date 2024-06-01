using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AARP_BE.Models;

public class AppPayment : Payment
{
    /// <summary>
    /// Client identifer that represent an account from cliente of the application and a customer on Administration Application
    /// </summary>
    public string? ClientId { get; set; }
    /// <summary>
    /// Indicate if the payment was validated and complete or not
    /// </summary>
    public bool Validate { get; set; }
    /// <summary>
    /// Person that must to validate the correct and full payment 
    /// </summary>
    public string? Validator { get; set; }
    /// <summary>
    /// Date in with this payment was successfuly validated
    /// </summary>
    public DateTime? ValidationDate { get; set; }
}
