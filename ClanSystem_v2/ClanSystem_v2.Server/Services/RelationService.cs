using MongoDB.Driver;
using Clan_System.Server.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using Microsoft.AspNetCore.Mvc;

namespace Clan_System.Server.Services
{
    public class RelationService
    {

        private readonly IMongoCollection<Relation> _relationCollection;

        public RelationService(IOptions<MongoDBSettings> mongoDBSettings)

        {
            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _relationCollection = database.GetCollection<Relation>(mongoDBSettings.Value.RelationCollection);
        }


        //Create a new Relation
        public async Task CreateRelationAsync(Relation relation)
        {
            await _relationCollection.InsertOneAsync(relation);
            return;
        }

        //Get all relations
        public async Task<List<Relation>> GetAsync()
        {
            return await _relationCollection.Find(new BsonDocument()).ToListAsync();
        }


        //Get a relation of the user of a clan he still member in
        public async Task<Relation> GetRelationByUserNameAsync(string username)
        {
            FilterDefinition<Relation> nameFilter = Builders<Relation>.Filter.Eq("username", username);
            FilterDefinition<Relation> membershipFilter = Builders<Relation>.Filter.Eq("isMember", true);
            FilterDefinition<Relation> combinedFilter = nameFilter & membershipFilter;

            return await _relationCollection.Find(combinedFilter).FirstOrDefaultAsync();
        }
        


        //Update User Relation Contributed points
        public async Task UpdateRelationPointsAsync(string username, [FromBody] Int32 pionts)
        {
            FilterDefinition<Relation> filter = Builders<Relation>.Filter.Eq("username", username);
            UpdateDefinition<Relation> update = Builders<Relation>.Update.Set("pointscontributed", pionts);
            await _relationCollection.UpdateOneAsync(filter, update);
            return;
        }

        //Update User Membership in a Relation
        public async Task UpdateRelationMembershipAsync(string username, [FromBody] Boolean isMember)
        {
            FilterDefinition<Relation> filter = Builders<Relation>.Filter.Eq("username", username);
            UpdateDefinition<Relation> update = Builders<Relation>.Update.Set("isMember", isMember);
            await _relationCollection.UpdateOneAsync(filter, update);
            return;
        }
        



        //Delete A relation with the seleceted user name
        public async Task DeleteRelationAsync(string username)
        {
            FilterDefinition<Relation> filter = Builders<Relation>.Filter.Eq("username", username);
            await _relationCollection.DeleteOneAsync(filter);
            return;
        }

        //Reste A relation with the seleceted clan name
        public async Task ResetRelationAsync(string clanname)
        {
            FilterDefinition<Relation> filter = Builders<Relation>.Filter.Eq("clanname", clanname);
            await _relationCollection.DeleteManyAsync(filter);
            return;
        }


    }
}
