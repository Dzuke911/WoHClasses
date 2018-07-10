using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WoH_classes.BasicClasses;
using WoH_classes.Enums;
using WoH_classes.GameFactories;
using WoH_classes.Managers;
using WoH_classes.Maps;
using Xunit;

namespace WoH_classes_Tests
{
    public class UnitTests
    {
        [Fact]
        public async Task ConstructorSuccess()
        {
            //Arrange
            const string playerId = "asd";
            UnitTypeAttributesManager utaManager = await UnitTypeAttributesManager.GetInstance("GameData/UnitTypeAttributes.json");
            UnitTypesManager utManager = await UnitTypesManager.GetInstance("GameData/UnitTypes.json", utaManager);

            MapFactory<Hex> mf = new MapFactory<Hex>();

            Map<Hex> map = mf.CreateMap(MapShape.Circle, 3);

            GamePlayersManager pm = new GamePlayersManager(new GameTeamsFactory());
            Player p = new Player(playerId);

            pm.AddTeam(p);

            //Act
            Unit u = new Unit(utManager.GetUnitType("GermanTank"), map.GetHex(0, 0), p, HexDirection.Top);

            //Assert
            Assert.NotNull(u);
        }

        [Fact]
        public async Task ToJsonSuccess()
        {
            //Arrange
            const string playerId = "asd";
            UnitTypeAttributesManager utaManager = await UnitTypeAttributesManager.GetInstance("GameData/UnitTypeAttributes.json");
            UnitTypesManager utManager = await UnitTypesManager.GetInstance("GameData/UnitTypes.json", utaManager);

            MapFactory<Hex> mf = new MapFactory<Hex>();

            Map<Hex> map = mf.CreateMap(MapShape.Circle, 3);

            GamePlayersManager pm = new GamePlayersManager(new GameTeamsFactory());
            Player p = new Player(playerId);

            pm.AddTeam(p);

            Unit u = new Unit(utManager.GetUnitType("GermanTank"), map.GetHex(0, 0), p, HexDirection.Top);

            //Act
            JObject obj = u.ToJson();

            //Assert
            Assert.NotNull(obj);
        }
    }
}
