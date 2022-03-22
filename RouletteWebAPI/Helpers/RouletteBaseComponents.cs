using RouletteWebAPI.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RouletteWebAPI.Helpers
{
    public class RouletteBaseComponents
    {
        public int CurrentNumberIndex { get; protected set; }

        public WheelNumber WinningNumber { get; protected set; }

        public WheelNumberColour? Colour { get; set; }

        public bool Running { get; protected set; }

      
    }
}
