using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using WoHclassLibrary;

namespace WoH_classesTests
{
    [TestFixture]
    class MapTests
    {
        [Test]
        public void Map_Constructor_OK()
        {
            //Act
            Map map = new Map();

            //Assert
            Assert.NotNull(map);
            Assert.NotNull(map.Hexes);
        }

        [Test]
        public void Map_GetHex_Fail()
        {
            //Act
            Map map = new Map();

            //Assert
            Assert.AreEqual(null, map.GetHex(new Coords(0, 0)));
        }
    }
}
