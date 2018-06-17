﻿using System;
using System.Collections.Generic;
using System.Text;
using WoH_classes.Interfaces;
using System.Linq;
using WoH_classes.BasicClasses;
using WoH_classes.Resources;
using Newtonsoft.Json.Linq;

namespace WoH_classes.Maps
{
    public class Map<T> where T : BaseHex
    {
        public readonly List<T> Hexes;

        private readonly T _center;

        public Map(T hex)
        {
            Hexes = new List<T>();
            _center = hex;
            Hexes.Add(hex);
        }

        public bool AddHex(T hex)
        {
            if (!IsHex(hex.Coords))
            {
                Hexes.Add(hex);
                return true;
            }

            return false;
        }

        public bool IsHex(Coords coords)
        {
            return Hexes.Exists(h => h.Coords.X == coords.X && h.Coords.Y == coords.Y);
        }

        public T GetHex(Coords coords)
        {
            return Hexes.SingleOrDefault(h => h.Coords.X == coords.X && h.Coords.Y == coords.Y);
        }

        public int GetHexesCount()
        {
            return Hexes.Count();
        }

        public int GetMaxX()
        {
            int result = _center != null ? _center.Coords.X : throw new InvalidOperationException(CodeErrors.MapNotCreated);
            foreach (T hex in Hexes)
            {
                if (result < hex.Coords.X)
                    result = hex.Coords.X;
            }
            return result;
        }

        public int GetMinX()
        {
            int result = _center != null ? _center.Coords.X : throw new InvalidOperationException(CodeErrors.MapNotCreated);
            foreach (T hex in Hexes)
            {
                if (result > hex.Coords.X)
                    result = hex.Coords.X;
            }
            return result;
        }

        public int GetMaxY()
        {
            int result = _center != null ? _center.Coords.Y : throw new InvalidOperationException(CodeErrors.MapNotCreated);
            foreach (T hex in Hexes)
            {
                if (result < hex.Coords.Y)
                    result = hex.Coords.Y;
            }
            return result;
        }

        public int GetMinY()
        {
            int result = _center != null ? _center.Coords.Y : throw new InvalidOperationException(CodeErrors.MapNotCreated);
            foreach (T hex in Hexes)
            {
                if (result > hex.Coords.Y)
                    result = hex.Coords.Y;
            }
            return result;
        }

        public Coords GetMapSize()
        {
            return new Coords(GetMaxX() - GetMinX() + 1, GetMaxY() - GetMinY() + 1);
        }

        public Coords GetMapCenterOffset()
        {
            return new Coords(_center.Coords.X - GetMinX(), _center.Coords.Y - GetMinY());
        }

        public JObject ToJson()
        {
            JObject hex;
            JArray hexes = new JArray();

            T topHexId,topRightHexId,bottomRightHexId,bottomHexId,bottomLeftHexId,topLeftHexId;

            foreach (T h in Hexes)
            {
                hex = new JObject(new JProperty(MapJsonStrings.HexId, h.Id),
                    new JProperty(MapJsonStrings.XCoord, h.Coords.X),
                    new JProperty(MapJsonStrings.YCoord, h.Coords.Y));

                hexes.Add(hex);
            }

            int maxX = GetMaxX();
            int minX = GetMinX();
            int maxY = GetMaxY();
            int minY = GetMinY();
            int sizeX = maxX - minX + 1;
            int sizeY = maxY - minY + 1;
            int offsetX = _center.Coords.X - minX;
            int offsetY = _center.Coords.Y - minY;

            return new JObject(new JProperty(MapJsonStrings.Hexes, hexes),
                    new JProperty(MapJsonStrings.LengthY, sizeX),
                    new JProperty(MapJsonStrings.LengthX, sizeY),
                    new JProperty(MapJsonStrings.OffsetY, offsetX),
                    new JProperty(MapJsonStrings.OffsetX, offsetY));
        }
    }
}
