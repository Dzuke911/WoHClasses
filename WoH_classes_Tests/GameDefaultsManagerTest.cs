using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WoH_classes.DataManagers;
using WoH_classes.Managers;
using Xunit;

namespace WoH_classes_Tests
{
    public class GameDefaultsManagerTest
    {
        [Fact]
        public async Task ConstructorSuccess_SingletonOk()
        {
            GameDefaultsManager x1 = await GameDefaultsManager.GetInstance("GameData/GameDefaults.json");
            GameDefaultsManager x2 = await GameDefaultsManager.GetInstance("GameData/GameDefaults.json");

            Assert.Equal(x1.GetHashCode(), x2.GetHashCode());
        }

        [Theory]
        [InlineData(2, 8)]
        [InlineData(4, 12)]
        public async Task GetMapSizeSuccess(int playersCount, int mapSize)
        {
            GameDefaultsManager gdm = await GameDefaultsManager.GetInstance("GameData/GameDefaults.json");

            int res = gdm.GetDefaultMapSize(playersCount);

            Assert.Equal(mapSize, res);
        }
    }
}
