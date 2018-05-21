using System;
using System.Collections.Generic;
using System.Text;

namespace WoH_classes.BasicClasses
{
    public class Unit
    {
        public readonly UnitType Type;

        public Hex position { get; set; }

        public Unit( UnitType type, Hex pos)
        {
            position = pos;
            Type = type;
        }
    }
}
