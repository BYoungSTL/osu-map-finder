// ReSharper disable InconsistentNaming

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OsuMapFinder.Data.Entities.BaseEntity
{
    public class Entity<T>
    {
        [BsonRepresentation(BsonType.String)]
        public ObjectId _id { get; set; }
        [BsonRepresentation(BsonType.String)]
        public T EntityId { get; set; }
    }
}