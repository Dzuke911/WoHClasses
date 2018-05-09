using System;
using System.Collections.Generic;
using System.Text;
using WoH_classes.Interfaces;
using System.Linq;
using WoH_classes.BasicClasses;

namespace WoH_classes.Maps
{
    public class Map<T> where T : BaseHex
    {
        private readonly List<T> _hexes;

        private readonly T _center;

        public Map(T hex)
        {
            _hexes = new List<T>();
            _center = hex;
            _hexes.Add(hex);
        }
        
        public bool AddHex(T hex)
        {
            if (!IsHex(hex.Coords))
            {
                _hexes.Add(hex);
                return true;
            }

            return false;                
        }

        public bool IsHex(Coords coords)
        {
            return _hexes.Exists(h => h.Coords.X == coords.X && h.Coords.Y == coords.Y);
        }
    }
}
