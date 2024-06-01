using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;
using AARP_BE.Utilities;

namespace AARP_BE.Models
{
    public class UserType : ModelBase
    {
        /// <summary>
        /// Description to identify the role
        /// </summary>
        [BsonElement("RoleName")]
        [JsonPropertyName("RoleName")]
        public string RoleName { get; set; } = null!;
        /// <summary>
        /// Record identifier to Role
        /// </summary>
        public string RoleId { get; set; } = null!; // tbd types of roles for any given account
        /// <summary>
        /// Record identifier to Account
        /// </summary>
        public string AccountId { get; set; } = null!;
        /// <summary>
        /// Status User type has
        /// </summary>
        public GenericStatus Status { get; set; } = 0;
    }
}
