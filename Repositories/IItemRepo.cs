using DotnetRedis.Models;

namespace DotnetRedis.Repositories
{
    public interface IItemRepo
    {
        void CreateItem(Item item);

        Item? GetItemById(string id);

        IEnumerable<Item> GetItems();
    }
}
