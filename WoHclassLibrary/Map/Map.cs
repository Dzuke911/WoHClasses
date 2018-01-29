using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace WoHclassLibrary
{
    public class Map
    {
        private List<Hexagon> hexes { get; }

        public Map()
        {
            hexes = new List<Hexagon>();
        }

        public Hexagon GetHex( Coords c)
        {
            return hexes.Single(h=>(h.Coord.X == c.X && h.Coord.Y == c.Y));
        }

        public bool AddHex(Hexagon hex)
        {
            if (IsHex(hex.Coord))
                return false;
            else
            {
                hexes.Add(hex);
                return true;
            }
        }

        public bool RemoveHex(Hexagon hex)
        {
            if (IsHex(hex.Coord))
            {
                hexes.Remove(hex);
                return false;
            }
            else   
                return false;
        }

        public bool IsHex( Coords c)
        {
            try
            {
                Hexagon hex = hexes.Single(h => (h.Coord.X == c.X && h.Coord.Y == c.Y));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void clearHexes()
        {
            hexes.Clear();
        }
    }
}
