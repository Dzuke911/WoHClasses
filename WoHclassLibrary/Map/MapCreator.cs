using System;
using System.Collections.Generic;
using System.Text;

namespace WoHclassLibrary
{
    public class MapCreator
    {
        private List<Coords> temp = new List<Coords>();
        private List<Coords> nextTemp = new List<Coords>();
        private Dictionary<Coords, Hexagon> hexes;

        public Map CreateRound(int r)
        {
            Map ret = new Map();
            hexes = ret.Hexes;

            Hexagon center = new Hexagon(0, 0);
            hexes.Add(center.Coord, center);
            nextTemp.Add(center.Coord);
            //r--;

            while( r > 0)
            {
                temp.Clear();
                foreach(Coords c in nextTemp)
                {
                    temp.Add(c);
                }
                nextTemp.Clear();

                foreach(Coords c in temp)
                {
                    createNearbyHexes(c);
                }
                r--;
            }

            return ret;
        }

        private void createNearbyHexes(Coords coords)
        {
            Coords[] newCoords = hexes.GetValueOrDefault(coords).GetNearbyCoordsArray();
            Hexagon newHex;

            foreach (Coords c in newCoords)
            {
                if(hexes.ContainsKey(c))
                {
                    newHex = new Hexagon(c.X, c.Y);
                    hexes.Add(c,newHex);
                    nextTemp.Add(c);
                }
            }
        }
    }
}
