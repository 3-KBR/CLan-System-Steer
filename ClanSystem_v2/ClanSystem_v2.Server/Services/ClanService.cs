
using MongoDB.Driver;
using Clan_System.Server.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using Microsoft.AspNetCore.Mvc;

namespace Clan_System.Server.Services
{
    public class ClanService
    {
        private readonly IMongoCollection<Clan> _clansCollection;

        public ClanService(IOptions<MongoDBSettings> mongoDBSettings)

        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _clansCollection = database.GetCollection<Clan>(mongoDBSettings.Value.ClansCollection);
        }


        public async Task CreateAsync(Clan clan)
        {
            await _clansCollection.InsertOneAsync(clan);
            return;
        }

        public async Task<List<Clan>> GetAsync()
        {
            return await _clansCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<Clan> GetByClanAsync(string clanname)
        {
            FilterDefinition<Clan> filter = Builders<Clan>.Filter.Eq("clanname", clanname);
            return await _clansCollection.Find(filter).FirstOrDefaultAsync();
        }

        
        public async Task UpdateMembersAsync(string clanname,[FromBody] Int32 totalmembers)
        {
            FilterDefinition<Clan> filter = Builders<Clan>.Filter.Eq("clanname", clanname);
            UpdateDefinition<Clan> update = Builders<Clan>.Update.Set("totalmembers", totalmembers);
            await _clansCollection.UpdateOneAsync(filter, update);
            return ;
        }



        public async Task UpdatePointsAsync(string clanname, [FromBody] Int32 totalpoints)
        {
            FilterDefinition<Clan> filter = Builders<Clan>.Filter.Eq("clanname", clanname);
            UpdateDefinition<Clan> update = Builders<Clan>.Update.Set("totalpoints", totalpoints);
            await _clansCollection.UpdateOneAsync(filter, update);
            return ;
        }
        
    }
}
