﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using WoH_classes.BasicClasses;
using WoH_classes.Enums;
using WoH_classes.Interfaces;
using WoH_classes.Resources;

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

        private void CreateNearHexes(Map<T> map,T baseHex, List<T> nextCircle)
        {            
            foreach( HexDirection hd in SixDirections.Get() )
            {
                Coords coords = baseHex.GetNearbyHexCoords(hd);

                T newHex = CreateT(coords);

                if(map.AddHex( newHex ))
                {
                    baseHex.nearHexes[hd] = newHex;
                    newHex.nearHexes[hd.GetOposite()] = baseHex;
                }
            }
        }

        private T CreateT(Coords coords)
        {
            Type type = typeof(T);

            ConstructorInfo ci = type.GetConstructor( new Type[] { typeof(Coords)} );

            if (ci == null)
                throw new InvalidOperationException(CodeErrors.InvalidHexType);

            return (T)Activator.CreateInstance(typeof(T), coords);
        }
    }
}
