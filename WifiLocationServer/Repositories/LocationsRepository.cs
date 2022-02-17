using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WifiLocationServer.Entities;

namespace WifiLocationServer.Repositories
{
    public class LocationItemRepository : InterfaceLocationRepository
    {
        private readonly List<Item> items = new()
        {
            new Item
            {
                Id = Guid.NewGuid(),
                Location = "Hopwood",
                MAC = "00:00:75",
                MaxSignalStrength = -70,
                MinSignalStrength = -10
            },
            new Item
            {
                Id = Guid.NewGuid(),
                Location = "HOBBS",
                MAC = "00:00:7F",
                MaxSignalStrength = -59,
                MinSignalStrength = -9
            },
            new Item
            {
                Id = Guid.NewGuid(),
                Location = "SHEWEL",
                MAC = "00:00:6F",
                MaxSignalStrength = -40,
                MinSignalStrength = 0
            }
        };

        public async Task<IEnumerable<Item>> GetItemsAsync()
        {
            return await Task.FromResult(items);
        }

        public async Task<Item> GetItemAsync(Guid id)
        {
            var item = items.Where(item => item.Id == id).SingleOrDefault();
            return await Task.FromResult(item);
        }

        public async Task CreateItemAsync(Item item)
        {
            items.Add(item);
            await Task.CompletedTask;
        }

    }
}

