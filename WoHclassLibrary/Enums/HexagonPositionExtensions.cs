using System;
using System.Collections.Generic;
using System.Text;
using WoHclassLibrary.Resources;

namespace WoHclassLibrary.Enums
{
    public static class HexagonPositionExtensions
    {
        public static int ToInt(this HexagonPosition pos)
        {
            switch( pos)
            {
                case HexagonPosition.Top:
                    return 1;
                case HexagonPosition.TopRight:
                    return 2;
                case HexagonPosition.BottomRight:
                    return 3;
                case HexagonPosition.Bottom:
                    return 4;
                case HexagonPosition.BottomLeft:
                    return 5;
                case HexagonPosition.TopLeft:
                    return 6;
                default:
                    throw new InvalidOperationException(MapExceptions.UnknownHexagonPositionToInt);
            }
                

        }
    }
}
