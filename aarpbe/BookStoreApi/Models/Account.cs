using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;
using AARP_BE.Utilities;

namespace AARP_BE.Models
{
    public class Account : ModelBase
    {
        /// <summary>
        /// Name of the account
        /// </summary>
        [BsonElement("Name")]
        [JsonPropertyName("Name")]
        public string Name { get; set; } = null!;
        /// <summary>
        /// Identifer that exist on Application Administration side.
        /// </summary>
        public string? ClientId { get; set; }
        /// <summary>
        /// List of identifers of RentalComplext that belong to this account
        /// </summary>
        public IList<string>? RentalComplexId { get; set; }
        /// <summary>
        /// Address identifer that is registered for account
        /// </summary>
        public string AddressId { get; set; }
        /// <summary>
        /// Petty Cash Identifer that is managed in this Account
        /// </summary>
        public string? PettyCashId { get; set; }
        /// <summary>
        /// /// Record identifer to this Account
        /// </summary>
        public string? RecordId { get; set; }
        /// <summary>
        /// Specific status of this account
        /// </summary>
        public AccountStatus Status { get; set; } = 0;
    }
}
