using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using OsuMapFinder.Data.Configs;
using OsuMapFinder.Data.CRUDs.BaseService;
using OsuMapFinder.Data.Entities;
using OsuMapFinder.Data.Interfaces;

namespace OsuMapFinder.Data.CRUDs
{
    public class UserService(IMongoDatabase mongoDatabase) : BaseService<User>(mongoDatabase), IUserService
    {
        private readonly IMongoDatabase _mongoDatabase = mongoDatabase;

        public User GetUserByName(string username)
        {
            var bsonCollection = _mongoDatabase.GetCollection<BsonDocument>(nameof(User));

            return BsonSerializer.Deserialize<User>(bsonCollection.ToBsonDocument());
        }
    }
}
