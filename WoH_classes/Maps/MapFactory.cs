using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using WoH_classes.BasicClasses;
using WoH_classes.Enums;
using WoH_classes.Interfaces;
using WoH_Resources.Resources;

namespace WoH_classes.Maps
{
    public class MapFactory<T> where T:BaseHex
    {
        public Map<T> CreateMap( MapShape shape, int x, int y = 0)
        {
            switch(shape)
            {
                case MapShape.Circle:
                    return CreateCircleMap(x );
                case MapShape.Rectangle:
                    return CreateRectMap(x, y );
                default:
                    throw new InvalidOperationException();
            }
        }

        private Map<T> CreateCircleMap(int radius)
        {
            T center = CreateHex(new Coords(0,0),0);

            Map<T> resultMap = new Map<T>(center);

            List<T> currentHexes = new List<T> { center };
            List<T> newHexes = new List<T>();

            for (int i=0; i<radius; i++)
            {
                foreach(T hex in currentHexes)
                {
                    CreateNearHexes(resultMap, hex, newHexes);
                }

                currentHexes = newHexes;
                newHexes = new List<T>();
            }

            return resultMap;
        }

        private Map<T> CreateRectMap(int xMax, int yMax)
        {
            throw new NotImplementedException();
        }

        private void ConnectToHexes( T hex , Map<T> map)
        {
            T targetHex;

            foreach ( HexDirection hd in SixDirections.Get() )
            {
                targetHex = hex.nearHexes.GetValueOrDefault(hd) as T;

                if (targetHex == null)
                {
                    targetHex = map.GetHex(hex.GetNearbyHexCoords(hd));
                    if(targetHex != null )
                    {
                        hex.nearHexes.Add(hd, targetHex);
                        targetHex.nearHexes.Add(hd.GetOposite(), hex);
                    }
                }
            }
        }

        private void CreateNearHexes(Map<T> map,T baseHex, List<T> nextCircle)
        {            
            foreach( HexDirection hd in SixDirections.Get() )
            {
                T newHex;

                Coords coords = baseHex.GetNearbyHexCoords(hd);

                if( !map.IsHex(coords))
                {
                    newHex = CreateHex(coords, map.Hexes.Count);

                    map.AddHex(newHex);
                    ConnectToHexes(newHex, map);

                    nextCircle.Add(newHex);
                }             
            }
        }

        private T CreateHex(Coords coords, int id)
        {
            Type type = typeof(T);

            ConstructorInfo ci = type.GetConstructor( new Type[] { typeof(Coords), typeof(int)} );

            if (ci == null)
                throw new InvalidOperationException(CodeErrors.InvalidHexType);

            return (T)Activator.CreateInstance(typeof(T), coords , id);
        }
    }
}
