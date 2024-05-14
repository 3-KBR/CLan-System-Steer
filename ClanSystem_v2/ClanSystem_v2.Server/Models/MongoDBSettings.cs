namespace Clan_System.Server.Models
{
    public class MongoDBSettings
    {

        public string ConnectionURI { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string UsersCollection { get; set; } = null!; 
        public string ClansCollection { get; set; } = null!;
        public string RelationCollection { get; set; } = null!;


    }
}
