using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace WoH_classes.Enums
{
    public static class HexDirectionExtensions
    {
        public static IEnumerable<HexDirection> GetEnumerable(this HexDirection hd)
        {
            return new HexDirection[] {
                HexDirection.Top,
                HexDirection.TopRight,
                HexDirection.BottomRight,
                HexDirection.Bottom,
                HexDirection.BottomLeft,
                HexDirection.TopLeft
            };
        }
    }
}
