using MongoDB.Driver;
using System.Linq.Expressions;

public class MongoDBRepository<T> where T : class
{
    private readonly IMongoCollection<T> _collection;

    public MongoDBRepository(IMongoDatabase database, string collectionName)
    {
        _collection = database.GetCollection<T>(collectionName);
    }

    public async Task InsertAsync(T document)
    {
        await _collection.InsertOneAsync(document);
    }

    public async Task<List<T>> FindAsync(Expression<Func<T, bool>> filter)
    {
        var result = await _collection.Find(filter).ToListAsync();
        return result;
    }

}
