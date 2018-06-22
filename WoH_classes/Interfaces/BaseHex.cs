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
        protected List<Unit> _units;

        public Coords Coords{ get; }
        public Dictionary<HexDirection,BaseHex> nearHexes { get; }
        public int Id { get; }

        public BaseHex(int x, int y, int id)
        {
            Coords = new Coords(x, y);
            nearHexes = new Dictionary<HexDirection, BaseHex>();
            Id = id;
            _units = new List<Unit>();
        }

        public BaseHex(Coords coords, int id)
        {
            Coords = coords ?? throw new ArgumentNullException(nameof(coords), CodeErrors.InvalidHexCreation);
            nearHexes = new Dictionary<HexDirection, BaseHex>();
            Id = id;
            _units = new List<Unit>();
        }

        public abstract Coords GetNearbyHexCoords(HexDirection hd);
        public abstract bool AddUnit(Unit unit);
        public abstract void RemoveUnit(Unit unit);
        public abstract bool IsFreeForUnit(Unit enteringUnit);
        public abstract IEnumerable<Unit> GetUnits();
    }
}
