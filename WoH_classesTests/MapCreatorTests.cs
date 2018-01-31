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
        [TestCase(3,37)]
        [TestCase(4, 61)]
        [TestCase(5, 91)]
        public void MapCreator_CreateRound(int radius, int result)
        {
            //Arrange
            MapCreator mc = new MapCreator();

            //Act
            Map map = mc.CreateRound(radius);

            //Assert
            Assert.AreEqual(result,map.Count());
        }
    }
}
