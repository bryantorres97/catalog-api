using Catalog.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Catalog.Repositories
{
    public class MongoDBItemsRepository : IItemsRepository
    {
        private const string databaseName = "Catalog";
        private const string collectionName = "items";
        private readonly IMongoCollection<Item> _itemsCollection;
        private readonly FilterDefinitionBuilder<Item> _filterBuilder = Builders<Item>.Filter;
        public MongoDBItemsRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            _itemsCollection = database.GetCollection<Item>(collectionName);
        }
        public async void CreateItem(Item item)
        {
            await _itemsCollection.InsertOneAsync(item);
        }

        public async void DeleteItem(Guid id)
        {
            FilterDefinition<Item> filter = _filterBuilder.Eq(item => item.Id, id);
            await _itemsCollection.DeleteOneAsync(filter);
        }

        public Item GetItem(Guid id)
        {
            FilterDefinition<Item> filter = _filterBuilder.Eq(item => item.Id, id);
            return _itemsCollection.Find(filter).SingleOrDefault();
        }

        public IEnumerable<Item> GetItems()
        {
            return _itemsCollection.Find(new BsonDocument()).ToList();
        }

        public async void UpdateItem(Item item)
        {
            FilterDefinition<Item> filter = _filterBuilder.Eq(existingItem => existingItem.Id, item.Id);
            await _itemsCollection.ReplaceOneAsync(filter, item);
        }
    }
}
