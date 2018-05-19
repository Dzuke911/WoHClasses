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
        public readonly List<T> Hexes;

        private readonly T _center;

        public Map(T hex)
        {
            Hexes = new List<T>();
            _center = hex;
            Hexes.Add(hex);
        }
        
        public bool AddHex(T hex)
        {
            if (!IsHex(hex.Coords))
            {
                Hexes.Add(hex);
                return true;
            }

            return false;                
        }

        public bool IsHex(Coords coords)
        {
            return Hexes.Exists(h => h.Coords.X == coords.X && h.Coords.Y == coords.Y);
        }

        public T GetHex(Coords coords)
        {
            return Hexes.SingleOrDefault(h => h.Coords.X == coords.X && h.Coords.Y == coords.Y);
        }

        public int GetHexesCount()
        {
            return Hexes.Count();
        }
    }
}
