using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;
using AARP_BE.Utilities;

namespace AARP_BE.Models
{
    public class Address : ModelBase
    {
        public string Street { get; set; } = null!;

        public string Neighbourhood { get; set; } = null!;

        public string? StreetNumber { get; set; }

        public string? SuiteNumber { get; set; }

        public string City { get; set; } = null!;

        public string State { get; set; } = null!;

        public int ZipCode { get; set; } = 0;

        public GenericStatus Status { get; set; } = 0;
    }
}
