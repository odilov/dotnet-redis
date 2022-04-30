using System.Text.Json;
using DotnetRedis.Models;
using StackExchange.Redis;

namespace DotnetRedis.Repositories
{
    public class RedisItemRepo : IItemRepo
    {
        private readonly IConnectionMultiplexer _redis;

        public RedisItemRepo(IConnectionMultiplexer redis)
        {
            _redis = redis;
        }

        public void CreateItem(Item item)
        {
            if (item == null)
            {
                throw new ArgumentOutOfRangeException(nameof(item));
            }

            var db = _redis.GetDatabase();

            var serialItem = JsonSerializer.Serialize(item);

            db.StringSet(item.Id, serialItem);
        }

        public Item? GetItemById(string id)
        {
            var db = _redis.GetDatabase();

            var item = db.StringGet(id);

            if (!string.IsNullOrEmpty(item))
            {
                return JsonSerializer.Deserialize<Item>(item);
            }

            return null;
        }

        public IEnumerable<Item> GetItems()
        {
            throw new NotImplementedException();
        }
    }
}
