using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WifiLocationServer.Dtos
{
    public record ItemDto
    {
        public Guid Id { get; init; }
        public String Location { get; init; }
        public String MAC { get; init; }
        public float MaxSignalStrength { get; init; }
        public float MinSignalStrength { get; init; }
    }
}
