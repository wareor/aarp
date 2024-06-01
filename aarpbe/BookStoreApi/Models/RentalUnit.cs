using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;
using AARP_BE.Utilities;
using AARP_BE.Models;

namespace AARP_BE.Models
{
    public class RentalUnit : ModelBase
    {
        /// <summary>
        /// It's a reference to identify the deb for RentalUnit
        /// </summary>
        // <snippet_RentalUnitName>
        [BsonElement("Name")]
        [JsonPropertyName("Name")]
        public string RentalUnitName { get; set; } = null!;
        // </snippet_RentalUnitName>
        /// <summary>
        /// Record identifier to Addess
        /// </summary>
        public string? AddressId { get; set; }
        /// <summary>
        /// Record identifier to Owner user
        /// </summary>
        public string OwnerId { get; set; } = null!;
        /// <summary>
        /// Record identifier to Holder user
        /// </summary>
        public string HolderId { get; set; } = null!;
        /// <summary>
        /// Record identifier to Resident user
        /// </summary>
        public string ResidentId { get; set; } = null!;
        /// <summary>
        /// Record identifier to Peripheral
        /// </summary>
        public IList<string>? PeripheralId { get; set; }
        /// <summary>
        /// Record identifier to Service
        /// </summary>
        public IList<string>? ServiceId { get; set; }
        /// <summary>
        /// Record identifier to RentalUnitPayment
        /// </summary>
        public string RentalUnitPaymentId { get; set; } = null!;
        /// <summary>
        /// Record identifier to Record
        /// </summary>
        public string? RecordId { get; set; }
        /// <summary>
        /// Status RentalUnit has to be Rent or not
        /// </summary>
        public bool OpenToRent { get; set; }
        /// <summary>
        /// RentalUnit is in Rent or not
        /// </summary>
        public bool InRent { get; set; }
        /// <summary>
        /// Status RentalUnit has to be Sold or not
        /// </summary>
        public bool OpenToSale { get; set; }

        /// <summary>
        /// Address of RentalUnit
        /// </summary>
        //public Address? Address { get; set; }
        /// <summary>
        /// General Status to identify if the RentalUnit must pay or not
        /// </summary>
        public RentalUnitStatus Status { get; set; } = 0;
    }
}







