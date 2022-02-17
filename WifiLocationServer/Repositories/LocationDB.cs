using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WifiLocationServer.Entities;
using MongoDB.Driver;
using MongoDB.Bson;

namespace WifiLocationServer.Repositories
{
    public class LocationDB : InterfaceLocationRepository
    {
        private const string DATABASE_NAME = "wifiLocationSever";
        private const string COLLECTION_NAME = "Items";
        private readonly IMongoCollection<Item> itemsCollection;
        private readonly FilterDefinitionBuilder<Item> filterBuilder = Builders<Item>.Filter;
        public LocationDB(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(DATABASE_NAME);
            itemsCollection = database.GetCollection<Item>(COLLECTION_NAME);
        }
        public async Task CreateItemAsync(Item item)
        {
            await itemsCollection.InsertOneAsync(item);
        }

        public async Task<Item> GetItemAsync(Guid id)
        {
            var filter = filterBuilder.Eq(item => item.Id, id);
            return await itemsCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Item>> GetItemsAsync()
        {
            return await itemsCollection.Find(new BsonDocument()).ToListAsync();
        }
    }
}
