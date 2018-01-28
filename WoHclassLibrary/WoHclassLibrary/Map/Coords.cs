using System;
using System.Collections.Generic;
using System.Text;

namespace WoHclassLibrary.Map
{
    public class Coords
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Coords(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
