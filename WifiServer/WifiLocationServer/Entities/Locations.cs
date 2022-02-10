using System;
namespace WifiLocationServer.Entities
{
    public record Item
    {
        public Guid Id { get; init; }
        public String Location { get; init; }
        public String MAC { get; init; }
        public float SignalStrength { get; init; }

    }
}