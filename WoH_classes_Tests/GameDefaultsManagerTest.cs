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
        public void ConstructorSuccess_SingletonOk()
        {
            GameDefaultsManager gdm = new GameDefaultsManager("GameData/GameDefaults.json");

            Assert.NotNull(gdm);
        }

        [Theory]
        [InlineData(2, 8)]
        [InlineData(4, 12)]
        public void GetMapSizeSuccess(int playersCount, int mapSize)
        {
            GameDefaultsManager gdm = new GameDefaultsManager("GameData/GameDefaults.json");

            int res = gdm.GetDefaultMapSize(playersCount);

            Assert.Equal(mapSize, res);
        }
    }
}
