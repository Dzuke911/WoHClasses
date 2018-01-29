using NUnit.Framework;
using System;
using WoHclassLibrary;

namespace WoH_classesTests
{
    [TestFixture]
    public class HexagonTests
    {
        [Test]
        public void Hexagon_Constructor_OK()
        {
            //Act
            Hexagon hex = new Hexagon(1, 2);

            //Assert
            Assert.NotNull(hex);
        }

        [TestCase(-1, -2, HexagonPosition.Top, -1, -1)]
        [TestCase(-1, -2, HexagonPosition.TopRight, 0, -1)]
        [TestCase(-1, -2, HexagonPosition.BottomRight, 0, -2)]
        [TestCase(-1, -2, HexagonPosition.Bottom, -1, -3)]
        [TestCase(-1, -2, HexagonPosition.BottomLeft, -2, -2)]
        [TestCase(-1, -2, HexagonPosition.TopLeft, -2, -1)]
        [TestCase(0, 2, HexagonPosition.Top, 0, 3)]
        [TestCase(0, 2, HexagonPosition.TopRight, 1, 2)]
        [TestCase(0, 2, HexagonPosition.BottomRight, 1, 1)]
        [TestCase(0, 2, HexagonPosition.Bottom, 0, 1)]
        [TestCase(0, 2, HexagonPosition.BottomLeft, -1, 1)]
        [TestCase(0, 2, HexagonPosition.TopLeft, -1, 2)]
        public void Hexagon_GetNearbyCoords(int x, int y, HexagonPosition pos, int xRes, int yRes)
        {
            //Arrange
            Hexagon hex = new Hexagon(x, y);

            //Act
            int xNew = hex.GetNearbyCoords(pos).X;
            int yNew = hex.GetNearbyCoords(pos).Y;

            //Assert
            Assert.AreEqual(xRes, xNew);
            Assert.AreEqual(yRes, yNew);
        }

        [Test]
        public void Hexagon_GetNearbyCoordsArray()
        {
            //Arrange
            Hexagon hex = new Hexagon(1, 1);
            Coords[] expected = new Coords[] { new Coords(1,2), new Coords(2, 2), new Coords(2, 1), new Coords(1, 0), new Coords(0, 1), new Coords(0, 2) };


            //Act
            Coords[] result = hex.GetNearbyCoordsArray();

            //Assert
            Assert.AreEqual(expected.Length, result.Length);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i].X, result[i].X);
                Assert.AreEqual(expected[i].Y, result[i].Y);
            }
        }
    }
}
