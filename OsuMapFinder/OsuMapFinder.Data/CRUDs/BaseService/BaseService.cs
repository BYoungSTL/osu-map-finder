using MongoDB.Driver;
using OsuMapFinder.Data.Interfaces.BaseService;

namespace OsuMapFinder.Data.CRUDs.BaseService
{
    public abstract class BaseService<T>(IMongoDatabase mongoDatabase) : IBaseService<T>
    {
        public virtual void Add(T entity)
        {
            var collection = mongoDatabase.GetCollection<T>(typeof(T).Name);
            collection.InsertOneAsync(entity);
        }
    }
}
