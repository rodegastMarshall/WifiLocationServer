using System;
using System.Collections.Generic;
using WifiLocationServer.Entities;

namespace WifiLocationServer.Repositories
{
    public interface InterfaceLocationRepository
    {
        Item GetItem(Guid id);

        IEnumerable<Item> GetItems();
    }
}