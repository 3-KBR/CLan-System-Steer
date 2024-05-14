using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Clan_System.Server.Models
{
    public class Clan
    {

        [BsonId]
        [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("clanname"), BsonRepresentation(BsonType.String)]
        public string? clanName { get; set; }

        [BsonElement("totalmembers"), BsonRepresentation(BsonType.Int32)]
        public Int32? members { get; set; }

        [BsonElement("totalpoints"), BsonRepresentation(BsonType.Int32)]
        public Int32? points { get; set; }


    }
}
