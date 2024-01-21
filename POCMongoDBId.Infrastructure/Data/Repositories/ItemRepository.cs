using MongoDB.Bson;
using MongoDB.Driver;
using POCMongoDBId.Core.Entities;

namespace POCMongoDBId.Infrastructure.Data.Repositories
{
    public class ItemRepository
    {
        private readonly IMongoCollection<BsonDocument> _itemCollection;

        public ItemRepository(MongoDB mongoDB)
        {
            _itemCollection = mongoDB.DB.GetCollection<BsonDocument>("Item");

        }

        public void InsertItem(Item item)
        {
            var document = new BsonDocument
            {
                { "_id", new BsonString(item.Id.ToString()) },
                { "name", new BsonString(item.Name) },
                { "description", new BsonString(item.Description) },
                { "metadados", GetMetadadosArray(item.Metadados) }
            };
            _itemCollection.InsertOne(document);
        }

        public Item GetItemById(Guid itemId)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", new BsonString(itemId.ToString()));
            var result = _itemCollection.Find(filter).FirstOrDefault();

            // Convertendo o BsonDocument para a entidade Item
            if (result != null)
            {
                var item = new Item
                {
                    Id = Guid.Parse(result["_id"].AsString),
                    Name = result["name"].AsString,
                    Description = result["description"].AsString
                };
                return item;
            }

            return null;
        }

        private BsonArray GetMetadadosArray(List<Metadados> metadadosList)
        {
            var array = new BsonArray();
            foreach (var metadado in metadadosList)
            {
                var metadadoDoc = new BsonDocument
                {
                    { "Nome", new BsonString(metadado.Nome) },
                    { "Prioridade", new BsonInt32(metadado.Prioridade) },
                    { "Nhew", new BsonString(metadado.Nhew) },
                    { "Huehuehue", new BsonString(metadado.Huehuehue) }
                };
                array.Add(metadadoDoc);
            }
            return array;
        }
    }
}
