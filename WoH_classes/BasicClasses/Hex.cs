using System;
using System.Collections.Generic;
using System.Text;
using WoH_classes.Enums;
using WoH_classes.Interfaces;
using WoH_classes.Resources;

namespace WoH_classes.BasicClasses
{
    public class Hex : BaseHex
    {
        public Hex( int x, int y): base(x,y)
        {            
        }

        public Hex( Coords coords) : base(coords)
        {
        }

        public override Coords GetNearbyHexCoords(HexDirection hd)
        {
            switch(hd)
            {
                case HexDirection.Top:
                    return new Coords( Coords.X, Coords.Y + 1 );

                case HexDirection.TopRight:
                    return new Coords(Coords.X + 1, Coords.X % 2 == 0 ? Coords.Y : Coords.Y + 1 );

                case HexDirection.BottomRight:
                    return new Coords ( Coords.X + 1, Coords.X % 2 == 0 ? Coords.Y -1 : Coords.Y );

                case HexDirection.Bottom:
                    return new Coords ( Coords.X, Coords.Y - 1 );

                case HexDirection.BottomLeft:
                    return new Coords ( Coords.X - 1, Coords.X % 2 == 0 ? Coords.Y - 1 : Coords.Y );

                case HexDirection.TopLeft:
                    return new Coords ( Coords.X - 1, Coords.X % 2 == 0 ? Coords.Y  : Coords.Y + 1 );

                default :
                    throw new NotImplementedException(CodeErrors.UnknownHexDirection);
            }
        }
    }
}
