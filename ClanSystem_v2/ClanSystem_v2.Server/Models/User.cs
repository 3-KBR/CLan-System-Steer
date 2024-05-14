using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;   

namespace Clan_System.Server.Models
{
    public class User
    {

        [BsonId]
        [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("username"), BsonRepresentation(BsonType.String)]
        public string? UserName { get; set; }
    }
}
