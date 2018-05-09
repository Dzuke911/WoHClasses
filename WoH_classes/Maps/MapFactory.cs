using System;
using System.Collections.Generic;
using System.Text;
using WoH_classes.BasicClasses;
using WoH_classes.Enums;
using WoH_classes.Interfaces;

namespace WoH_classes.Maps
{
    public class MapFactory<T> where T:BaseHex
    {
        public Map<T> CreateMap(T center, MapShape shape, int x, int y)
        {
            switch(shape)
            {
                case MapShape.Circle:
                    return CreateCircleMap(center, x);
                case MapShape.Rectangle:
                    return CreateRectMap(center, x, y);
                default:
                    throw new InvalidOperationException();
            }
        }

        private Map<T> CreateCircleMap(T center,int radius)
        {
            Map<T> res = new Map<T>(center);
            return res;
        }

        private Map<T> CreateRectMap(T center, int xMax, int yMax)
        {
            throw new NotImplementedException();
        }
    }
}
