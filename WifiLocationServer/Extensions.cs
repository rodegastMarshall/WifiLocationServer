using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WifiLocationServer.Dtos;
using WifiLocationServer.Entities;

namespace WifiLocationServer
{
    public static class Extensions
    {
        public static ItemDto AsDto(this Item item)
        {
            return new ItemDto
            {
                Id = item.Id,
                Location = item.Location,
                MAC = item.MAC,
                MaxSignalStrength = item.MaxSignalStrength,
                MinSignalStrength = item.MinSignalStrength
            };
        }
    }
}
