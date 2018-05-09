using System;
using System.Collections.Generic;
using System.Text;
using WoH_classes.BasicClasses;
using WoH_classes.Enums;
using WoH_classes.Resources;

namespace WoH_classes.Interfaces
{
    public abstract class BaseHex
    {
        public  Coords Coords{ get; }

        public BaseHex(int x, int y)
        {
            Coords = new Coords(x, y);
        }

        public BaseHex(Coords coords)
        {
            Coords = coords ?? throw new ArgumentNullException(nameof(coords), CodeErrors.InvalidHexCreation);
        }

        public abstract Coords GetNearbyHexCoords(HexDirection hd);
    }
}
