using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using WoHclassLibrary;

namespace WoH_classesTests
{
    [TestFixture]
    class PathingTests
    {
        [Test]
        public void Pathing_Constructor_OK()
        {
            //Act
            Pathing pathing = new Pathing();

            //Assert
            Assert.NotNull(pathing);
        }

        [TestCase(1,1)]
        [TestCase(-1, 0)]
        [TestCase(3, 2)]
        public void Pathing_MainUnitsLimit_Constructor(int mainU, int mainUResult)
        {
            //Act
            Pathing pathing = new Pathing(true,true,mainU);

            //Assert
            Assert.AreEqual(mainUResult, pathing.MainUnits);
        }

        [TestCase(1, 1)]
        [TestCase(-1, 0)]
        [TestCase(3, 2)]
        public void Pathing_SupportUnitsLimit_Constructor(int suppU, int suppUResult)
        {
            //Act
            Pathing pathing = new Pathing(true, true, 0, suppU);

            //Assert
            Assert.AreEqual(suppUResult, pathing.SupportUnits);
        }

        [TestCase(1, 1)]
        [TestCase(-1, 0)]
        [TestCase(3, 2)]
        public void Pathing_MainUnitsLimit_Property(int mainU, int mainUResult)
        {
            //Arrange
            Pathing pathing = new Pathing();

            //Act
            pathing.MainUnits = mainU;

            //Assert
            Assert.AreEqual(mainUResult, pathing.MainUnits);
        }

        [TestCase(1, 1)]
        [TestCase(-1, 0)]
        [TestCase(3, 2)]
        public void Pathing_SupportUnitsLimit_Property(int suppU, int suppUResult)
        {
            //Arrange
            Pathing pathing = new Pathing();

            //Act
            pathing.MainUnits = suppU;

            //Assert
            Assert.AreEqual(suppUResult, pathing.SupportUnits);
        }
    }
}
