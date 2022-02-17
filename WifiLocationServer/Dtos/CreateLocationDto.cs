using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WifiLocationServer.Dtos
{
    public record CreateLocationDto
    {
        [Required]
        //[Range] this will require a range for signal strength
        public String Location { get; init; }
        public String MAC { get; init; }
        public float MaxSignalStrength { get; init; }
        public float MinSignalStrength { get; init; }
    }
}
