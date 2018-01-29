using System;
using System.Collections.Generic;

namespace WoHclassLibrary
{
    public class Hexagon
    {
        public int ID { get; }

        public Coords Coord { get; }

        public Hexagon(int x, int y)
        {
            Coord = new Coords(x, y);
        }

        public Coords GetNearbyCoords(HexagonPosition nearby)
        {
            switch (nearby)
            {
                case HexagonPosition.Top:
                    return new Coords(Coord.X, Coord.Y + 1);
                case HexagonPosition.TopRight:
                    if (Coord.X % 2 == 0)
                        return new Coords(Coord.X + 1, Coord.Y);
                    else
                        return new Coords(Coord.X + 1, Coord.Y+1);
                case HexagonPosition.BottomRight:
                    if (Coord.X % 2 == 0)
                        return new Coords(Coord.X + 1, Coord.Y - 1);
                    else
                        return new Coords(Coord.X + 1, Coord.Y);
                case HexagonPosition.Bottom:
                    return new Coords(Coord.X, Coord.Y - 1);
                case HexagonPosition.TopLeft:
                    if (Coord.X % 2 == 0)
                        return new Coords(Coord.X - 1, Coord.Y);
                    else
                        return new Coords(Coord.X - 1, Coord.Y+1);
                case HexagonPosition.BottomLeft:
                    if (Coord.X % 2 == 0)
                        return new Coords(Coord.X - 1, Coord.Y - 1);
                    else
                        return new Coords(Coord.X - 1, Coord.Y);
                default:
                    throw new InvalidOperationException("Unknown nearby hexagon");
            }
        }

        public Coords[] GetNearbyCoordsArray()
        {
            return new Coords[] 
            {
                GetNearbyCoords(HexagonPosition.Top),
                GetNearbyCoords(HexagonPosition.TopRight),
                GetNearbyCoords(HexagonPosition.BottomRight),
                GetNearbyCoords(HexagonPosition.Bottom),
                GetNearbyCoords(HexagonPosition.BottomLeft),
                GetNearbyCoords(HexagonPosition.TopLeft),
            };
        }
    }
}
