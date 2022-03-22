using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RouletteWebAPI.Models.Base
{
    public class WheelNumber
    {
        public int Number { get; }
        public WheelNumberColour Colour { get; }

        public bool selected { get; set; }
        public WheelNumber(int number, WheelNumberColour colour)
        {
            Number = number;
            Colour = colour;
        }

       
    }
}
