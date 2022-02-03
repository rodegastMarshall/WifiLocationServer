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
                MAC = "XEROX",
                SignalStrength = -70
            },
            new Item
            {
                Id = Guid.NewGuid(),
                Location = "HOBBS",
                MAC = "MATRIX",
                SignalStrength = -59
            },
            new Item
            {
                Id = Guid.NewGuid(),
                Location = "SHEWEL",
                MAC = "CAMEX",
                SignalStrength = -40
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
    }
}

