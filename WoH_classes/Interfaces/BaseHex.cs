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
        public Coords Coords{ get; }
        public Dictionary<HexDirection,BaseHex> nearHexes { get; }
        public int Id { get; }

        public BaseHex(int x, int y, int id)
        {
            Coords = new Coords(x, y);
            nearHexes = new Dictionary<HexDirection, BaseHex>();
            Id = id;
        }

        public BaseHex(Coords coords, int id)
        {
            Coords = coords ?? throw new ArgumentNullException(nameof(coords), CodeErrors.InvalidHexCreation);
            nearHexes = new Dictionary<HexDirection, BaseHex>();
            Id = id;
        }

        public abstract Coords GetNearbyHexCoords(HexDirection hd);
    }
}
