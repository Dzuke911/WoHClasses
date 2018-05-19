using System;
using System.Collections.Generic;
using System.Text;
using WoH_classes.BasicClasses;
using WoH_classes.Enums;
using Xunit;

namespace WoH_classes_Tests
{
    public class HexTests
    {
        [Fact]
        public void ConstructorSuccess()
        {
            //Act
            Hex h = new Hex(new Coords ( 1, -1 ),1);

            //Assert
            Assert.NotNull(h);
        }

        [Fact]
        public void ConstructorFail_NullArgument()
        {
            //Assert
            Assert.Throws<ArgumentNullException>("coords",() => { Hex h = new Hex(null,1); } );
        }

        [Theory]
        [InlineData(0,0,HexDirection.Top,0,1)]
        [InlineData(0, 0, HexDirection.TopRight, 1, 0)]
        [InlineData(0, 0, HexDirection.BottomRight, 1, -1)]
        [InlineData(0, 0, HexDirection.Bottom, 0, -1)]
        [InlineData(0, 0, HexDirection.BottomLeft, -1, -1)]
        [InlineData(0, 0, HexDirection.TopLeft, -1, 0)]
        [InlineData(-1, -1, HexDirection.Top, -1, 0)]
        [InlineData(-1, -1, HexDirection.TopRight, 0, 0)]
        [InlineData(-1, -1, HexDirection.BottomRight, 0, -1)]
        [InlineData(-1, -1, HexDirection.Bottom, -1, -2)]
        [InlineData(-1, -1, HexDirection.BottomLeft, -2, -1)]
        [InlineData(-1, -1, HexDirection.TopLeft, -2, 0)]
        public void GetNearbyHexCoords(int x, int y, HexDirection hd, int resX, int resY)
        {
            Hex h = new Hex(x, y, 1);

            Coords c = h.GetNearbyHexCoords(hd);

            Assert.Equal(resX, c.X);
            Assert.Equal(resY, c.Y);
        }
    }
}
