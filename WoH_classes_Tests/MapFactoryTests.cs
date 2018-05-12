using System;
using System.Collections.Generic;
using System.Text;
using WoH_classes.BasicClasses;
using WoH_classes.Enums;
using WoH_classes.Maps;
using Xunit;

namespace WoH_classes_Tests
{
    public class MapFactoryTests
    {
        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 7)]
        [InlineData(2, 19)]
        [InlineData(3, 37)]
        public void CreateMapSuccess(int radius, int hexesCount)
        {
            //Arrange
            MapFactory<Hex> mf = new MapFactory<Hex>();

            //Act
            Map<Hex> map = mf.CreateMap(MapShape.Circle, radius);

            //Assert
            Assert.Equal(hexesCount, map.GetHexesCount());
        }
    }
}
