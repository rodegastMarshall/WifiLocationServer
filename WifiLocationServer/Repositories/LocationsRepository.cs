using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<Item> GetItems()
        {
            return items;
        }

        public Item GetItem(Guid id)
        {
            return items.Where(item => item.Id == id).SingleOrDefault();
        }

        public void CreateItem(Item item)
        {
            items.Add(item);
        }

    }
}

