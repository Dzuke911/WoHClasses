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
        }

        [Test]
        public void Map_GetHex_Fail()
        {
            //Act
            Map map = new Map();

            //Assert
            var ex = Assert.Throws<InvalidOperationException>(()=>map.GetHex(new Coords(0,0)));
            Assert.AreEqual(MapExceptions.MapNotContainHex,ex.Message);
        }

        [Test]
        public void Map_GetHex_NullArgFail()
        {
            //Act
            Map map = new Map();

            //Assert
            var ex = Assert.Throws<InvalidOperationException>(() => map.GetHex(null));
            Assert.AreEqual("Parameter name:c", ex.Message);
        }
    }
}
