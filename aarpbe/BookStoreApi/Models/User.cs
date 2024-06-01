// <snippet_UsingSystemTextJsonSerialization>
using System.Text.Json.Serialization;
using AARP_BE.Utilities;
// </snippet_UsingSystemTextJsonSerialization>
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AARP_BE.Models
{
    public class User : ModelBase
    {
        /// <summary>
        /// The email account reference to identify the user and access to the system
        /// </summary>
        public string? Email { get; set; }
        /// <summary>
        /// Password to access to the system
        /// </summary>
        public string? Password { get; set; }
        /// <summary>
        /// Unique name to indentify the user
        /// </summary>
        [BsonElement("Name")]
        [JsonPropertyName("Name")]
        public string? UserName { get; set; }
        /// <summary>
        /// Name or Names that the user is registered in the country
        /// </summary>
        public string? Names { get; set; }
        /// <summary>
        /// FirstLastName that user is registered in the Official Personal ID
        /// </summary>
        public string? FirstLastName { get; set; }
        /// <summary>
        /// SecondLastName that user is registered in the Official Personal ID
        /// </summary>
        public string? SecondLastName { get; set; }
        /// <summary>
        /// BirthdayDate that user is registered in the Official Personal ID (optional)
        /// </summary>
        public DateTime? BirthdayDate { get; set; }
        /// <summary>
        /// Record identifier to Address
        /// </summary>
        public IList<string>? AddressId { get; set; }
        /// <summary>
        /// Mobile Number that the user registered
        /// </summary>
        public string? MobileNumber { get; set; }
        /// <summary>
        /// List of accounts in which the user is associated
        /// </summary>
        public IList<string>? AccountId { get; set; }
        /// <summary>
        /// List where the user is a holder
        /// </summary>
        public IList<string>? HolderId { get; set; }
        /// <summary>
        /// List of Permissions the user has
        /// </summary>
        public IList<UserType>? UserRoles { get; set; } = null!;
        /// <summary>
        /// Record identifier to Record
        /// </summary>
        public string? RecordId { get; set; }
        /// <summary>
        /// ID user has to registered
        /// </summary>
        public OfficialPersonalIDType OfficialPersonalID { get; set; } = 0;
        /// <summary>
        /// Status user account has
        /// </summary>
        public GenericStatus Status { get; set; } = 0;
    }
}

