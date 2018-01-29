using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using WoHclassLibrary;

namespace WoH_classesTests
{
    [TestFixture]
    class MapCreatorTests
    {
        [Test]
        public void MapCreator_CreateRound()
        {
            //Arrange
            MapCreator mc = new MapCreator();

            //Act
            Map map = mc.CreateRound(3);

            //Assert
            Assert.AreEqual(18,map.Hexes.Count);
        }
    }
}
