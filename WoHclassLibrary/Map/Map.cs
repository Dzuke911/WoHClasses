using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using WoHclassLibrary.Resources;

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
            if (c == null)
                throw new ArgumentNullException(nameof(c));
            foreach (Hexagon h in hexes)
            {
                if (h.Coord.X == c.X && h.Coord.Y == c.Y)
                    return h;
            }
            throw new InvalidOperationException(MapExceptions.MapNotContainHex);
        }

        public void AddHex(Hexagon hex)
        {
            if (hex == null)
                throw new ArgumentNullException(nameof(hex));
            if (ContainsHex(hex.Coord))
                throw new InvalidOperationException(MapExceptions.MapAlreadyContainHex);
            else
                hexes.Add(hex);
        }

        public void RemoveHex(Hexagon hex)
        {
            if (hex == null)
                throw new ArgumentNullException(nameof(hex));
            if (ContainsHex(hex.Coord))
            {
                hexes.Remove(hex);
            }
            else
                throw new InvalidOperationException(MapExceptions.MapNotContainHex);
        }

        public bool ContainsHex( Coords c)
        {
            if (c == null)
                throw new ArgumentNullException(nameof(c));
            foreach (Hexagon h in hexes)
            {
                if (h.Coord.X == c.X && h.Coord.Y == c.Y)
                    return true;
            }
            return false;
        }

        public void ClearHexes()
        {
            hexes.Clear();
        }

        public int Count()
        {
            return hexes.Count;
        }

        public void ConnectNearbyHexes()
        {
  /*          foreach(Hexagon hex in hexes)
            {
                Coords[] coords = hex.GetNearbyCoordsArray();

                foreach (Coords c in newCoords)
                {
                    if (ContainsHex(c))
                    {
                        newHex = new Hexagon(c.X, c.Y);
                        map.AddHex(newHex);
                        nextTemp.Add(c);
                    }
                }
            } */
        }
    }
}
