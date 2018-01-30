using System;
using System.Collections.Generic;
using System.Text;

namespace WoHclassLibrary
{
    public class MapCreator
    {
        private List<Coords> temp = new List<Coords>();
        private List<Coords> nextTemp = new List<Coords>();
        private Map map = new Map();

        public Map CreateRound(int r)
        {
            Hexagon center = new Hexagon(0, 0);
            map.AddHex(center);
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
            return map;
        }

        private void createNearbyHexes(Coords coords)
        {
            Coords[] newCoords = map.GetHex(coords).GetNearbyCoordsArray();
            Hexagon newHex;

            foreach (Coords c in newCoords)
            {
                if(!map.ContainsHex(c))
                {
                    newHex = new Hexagon(c.X, c.Y);
                    map.AddHex(newHex);
                    nextTemp.Add(c);
                }
            }
        }
    }
}
