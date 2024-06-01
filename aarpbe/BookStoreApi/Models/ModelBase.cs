// <snippet_UsingSystemTextJsonSerialization>
using System.Text.Json.Serialization;
using AARP_BE.Utilities;
// </snippet_UsingSystemTextJsonSerialization>
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AARP_BE.Models
{
    public class ModelBase
    {
        /// <summary>
        /// Default identifer of each document on the database
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        /// <summary>
        /// Short or second identifer of this entity
        /// </summary>
        public string Code { get; set; } // JALEF: agregar una función para evitar que se agreguen codigos de entidades repetidas mediante una consulta en la colección de documentos de una cuenta.
        /// <summary>
        /// Logical state that indicate if this entity was deleted and would not be returned on a normal query
        /// </summary>
        public bool IsDeleted { get; set; } = false;
        /// <summary>
        /// Date at this entity register was created
        /// </summary>
        public DateTime? CreationDate { get; set; }
        /// <summary>
        /// Last Date at this entity register was updated
        /// </summary>
        public DateTime? UpdateDate { get; set; }
        /// <summary>
        /// Date at this entity register was deleted
        /// </summary>
        public DateTime? DeleteDate { get; set; }
    }
}
