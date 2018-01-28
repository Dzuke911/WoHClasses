using System;
using System.Collections.Generic;
using System.Text;

namespace WoHclassLibrary
{
    public static class HexagonRelations
    {
        public static HexagonPosition GetRelation(HexagonPosition pos)
        {
            switch (pos)
            {
                case HexagonPosition.BottomLeft:
                    return HexagonPosition.TopRight;
                case HexagonPosition.BottomRight:
                    return HexagonPosition.TopLeft;
                case HexagonPosition.TopLeft:
                    return HexagonPosition.BottomRight;
                case HexagonPosition.TopRight:
                    return HexagonPosition.BottomLeft;
                case HexagonPosition.Left:
                    return HexagonPosition.Right;
                case HexagonPosition.Right:
                    return HexagonPosition.Left;
                default:
                    throw new Exception("Unknown Hexagon Position");
            }
        }

        public static Coords GetCoords(HexagonPosition pos)
        {
            switch (pos)
            {
                case HexagonPosition.BottomLeft:
                    return new Coords(-1, -1);
                case HexagonPosition.BottomRight:
                    return new Coords(-1, 1);
                case HexagonPosition.TopLeft:
                    return new Coords(1, -1);
                case HexagonPosition.TopRight:
                    return new Coords(1, 1);
                case HexagonPosition.Left:
                    return new Coords(-1, 0);
                case HexagonPosition.Right:
                    return new Coords(1, 0);
                default:
                    throw new Exception("Unknown Hexagon Position");
            }
        }

        public static readonly HexagonPosition[] HexPosArray = new HexagonPosition[] { HexagonPosition.TopRight , HexagonPosition.Right , HexagonPosition.BottomRight , HexagonPosition.BottomLeft, HexagonPosition.Left, HexagonPosition.TopLeft };
    }
}
