using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WoH_classes.Managers;
using Xunit;

namespace WoH_classes_Tests
{
    public class UnitTypeAttributesManagerTests
    {
        [Fact]
        public async Task GetInstanceSuccess()
        {
            UnitTypeAttributesManager x = await UnitTypeAttributesManager.GetInstance("GameData/UnitTypeAttributes.json");

            Assert.NotNull(x);
        }

        [Fact]
        public async Task GetInstanceFail_WrongFilePath()
        {
            //Assert
            await Assert.ThrowsAsync<ArgumentException>( async () => { UnitTypeAttributesManager x = await UnitTypeAttributesManager.GetInstance("gg"); });
        }
    }
}
