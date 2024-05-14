
using MongoDB.Driver;
using Clan_System.Server.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;


namespace Clan_System.Server.Services
{
    public class UserService
    {

        
        private readonly IMongoCollection<User> _usersCollection;

        public UserService(IOptions<MongoDBSettings> mongoDBSettings)

        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
           IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
           _usersCollection = database.GetCollection<User>(mongoDBSettings.Value.UsersCollection);
        }

        public async Task CreateAsync(User user)
        {
            await _usersCollection.InsertOneAsync(user);
            return;
        }

        public async Task<List<User>> GetAsync()
        {
            return await _usersCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task DeleteAsync(string username)
        {
            FilterDefinition<User> filter = Builders<User>.Filter.Eq("username",username);
            await _usersCollection.DeleteOneAsync(filter);
            return;
        }


        // get user by username
        public async Task<User> GetUserByUsername(string username)
        {
            return await _usersCollection.Find<User>(user => user.UserName == username).FirstOrDefaultAsync();
        }


    }
}
