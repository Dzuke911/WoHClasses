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
                case HexagonPosition.Top:
                    return HexagonPosition.Bottom;
                case HexagonPosition.TopRight:
                    return HexagonPosition.BottomLeft;
                case HexagonPosition.BottomRight:
                    return HexagonPosition.TopLeft;
                case HexagonPosition.Bottom:
                    return HexagonPosition.Top;
                case HexagonPosition.BottomLeft:
                    return HexagonPosition.TopRight;
                case HexagonPosition.TopLeft:
                    return HexagonPosition.BottomRight;
                default:
                    throw new Exception("Unknown Hexagon Position");
            }
        }
    }
}
