using System;
using System.Collections.Generic;
using System.Text;
using WoH_classes.Resources;

namespace WoH_classes.Enums
{
    public enum HexDirection
    {
        Top,
        TopRight,
        BottomRight,
        Bottom,
        BottomLeft,
        TopLeft
    }

    public static class HexDirectionExtensions
    {
        public static HexDirection GetOposite(this HexDirection hd)
        {
            switch (hd)
            {
                case HexDirection.Top:
                    return HexDirection.Bottom;
                case HexDirection.TopRight:
                    return HexDirection.BottomLeft;
                case HexDirection.BottomRight:
                    return HexDirection.TopLeft;
                case HexDirection.Bottom:
                    return HexDirection.Top;
                case HexDirection.BottomLeft:
                    return HexDirection.TopRight;
                case HexDirection.TopLeft:
                    return HexDirection.BottomRight;
                default:
                    throw new NotImplementedException(CodeErrors.UnknownHexDirection);
            }
        }
    }

    public static class SixDirections
    {
        public static IEnumerable<HexDirection> Get()
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
