using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WoH_classes.Managers;
using Xunit;

namespace WoH_classes_Tests
{
    public class UnitTypesManagerTests
    {
        [Fact]
        public async Task ConstructorSuccess_SingletonOk()
        {
            UnitTypeAttributesManager utaManager = await UnitTypeAttributesManager.GetInstance("GameData/UnitTypeAttributes.json");
            UnitTypesManager x1 = await UnitTypesManager.GetInstance("GameData/UnitTypes.json", utaManager);
            UnitTypesManager x2 = await UnitTypesManager.GetInstance("GameData/UnitTypes.json", utaManager);

            Assert.Equal(x1.GetHashCode(),x2.GetHashCode());
        }

        [Fact]
        public async Task ConstructorSuccess()
        {
            UnitTypeAttributesManager utaManager = await UnitTypeAttributesManager.GetInstance("GameData/UnitTypeAttributes.json");
            UnitTypesManager x = await UnitTypesManager.GetInstance("GameData/UnitTypes.json", utaManager);

            Assert.NotNull(x);
        }
    }
}
