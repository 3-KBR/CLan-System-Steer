
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace Clan_System.Server.Models
{
    public class Relation
    {

        [BsonId]
        [BsonElement("_id"), BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("username"), BsonRepresentation(BsonType.String)]
        public string? UserName { get; set; }

        [BsonElement("clanname"), BsonRepresentation(BsonType.String)]
        public string? ClanName { get; set; }

        [BsonElement("pointscontributed"), BsonRepresentation(BsonType.Int32)]
        public int pointContributed { get; set; }

        [BsonElement("isMember"), BsonRepresentation(BsonType.Boolean)]
        public bool isMember { get; set; }


    }
}
