using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WifiLocationServer.Entities;

namespace WifiLocationServer.Repositories
{
    public interface InterfaceLocationRepository
    {
        Task<Item> GetItemAsync(Guid id);

        Task<IEnumerable<Item>> GetItemsAsync();

        Task CreateItemAsync(Item item);

        Task UpdateItemAsync(Item item);

        Task DeleteItemAsync(Guid id);
    }
}