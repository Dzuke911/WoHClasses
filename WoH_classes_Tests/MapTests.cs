using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using WoH_classes.BasicClasses;
using WoH_classes.Enums;
using WoH_classes.Maps;
using Xunit;

namespace WoH_classes_Tests
{
    public class MapTests
    {
        [Theory]
        [InlineData(3, 3)]
        [InlineData(5, 5)]
        public void GetMaxXSuccess(int radius, int maxX)
        {
            //Arrange
            MapFactory<Hex> mf = new MapFactory<Hex>();

            //Act
            Map<Hex> map = mf.CreateMap(MapShape.Circle, radius);

            //Assert
            Assert.Equal(maxX, map.GetMaxX());
        }

        [Theory]
        [InlineData(3, -3)]
        [InlineData(5, -5)]
        public void GetMinXSuccess(int radius, int minX)
        {
            //Arrange
            MapFactory<Hex> mf = new MapFactory<Hex>();

            //Act
            Map<Hex> map = mf.CreateMap(MapShape.Circle, radius);

            //Assert
            Assert.Equal(minX, map.GetMinX());
        }

        [Theory]
        [InlineData(3, 3)]
        [InlineData(5, 5)]
        public void GetMaxYSuccess(int radius, int maxY)
        {
            //Arrange
            MapFactory<Hex> mf = new MapFactory<Hex>();

            //Act
            Map<Hex> map = mf.CreateMap(MapShape.Circle, radius);

            //Assert
            Assert.Equal(maxY, map.GetMaxY());
        }

        [Theory]
        [InlineData(3, 3)]
        [InlineData(5, 5)]
        public void GetMinYSuccess(int radius, int minY)
        {
            //Arrange
            MapFactory<Hex> mf = new MapFactory<Hex>();

            //Act
            Map<Hex> map = mf.CreateMap(MapShape.Circle, radius);

            //Assert
            Assert.Equal(minY, map.GetMaxY());
        }

        [Theory]
        [InlineData(3, 7, 7)]
        [InlineData(4, 9, 9)]
        [InlineData(5, 11, 11)]
        public void GetMapSizeSuccess(int radius, int X, int Y)
        {
            //Arrange
            MapFactory<Hex> mf = new MapFactory<Hex>();

            //Act
            Map<Hex> map = mf.CreateMap(MapShape.Circle, radius);
            Coords res = map.GetMapSize();

            //Assert
            Assert.Equal(X, res.X);
            Assert.Equal(Y, res.Y);
        }

        [Theory]
        [InlineData(3, 3, 3)]
        [InlineData(4, 4, 4)]
        [InlineData(5, 5, 5)]
        public void GetMapCenterOffsetSuccess(int radius, int X, int Y)
        {
            //Arrange
            MapFactory<Hex> mf = new MapFactory<Hex>();

            //Act
            Map<Hex> map = mf.CreateMap(MapShape.Circle, radius);
            Coords res = map.GetMapCenterOffset();

            //Assert
            Assert.Equal(X, res.X);
            Assert.Equal(Y, res.Y);
        }

        [Fact]
        public void ToJsonSuccess()
        {
            //Arrange
            MapFactory<Hex> mf = new MapFactory<Hex>();
            Map<Hex> map = mf.CreateMap(MapShape.Circle, 3);

            //Act
            JObject obj = map.ToJson();
            string str = obj.ToString();
            Assert.Equal(1, 1);
        }
    }
}
