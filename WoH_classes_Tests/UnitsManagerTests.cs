using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WoH_classes.BasicClasses;
using WoH_classes.Enums;
using WoH_classes.Managers;
using WoH_classes.Maps;
using Xunit;

namespace WoH_classes_Tests
{
    public class UnitsManagerTests
    {
        [Fact]
        public async Task AddUnitSuccess()
        {
            //Arrange
            UnitsManager um = new UnitsManager();
            
            UnitTypeAttributesManager utaManager = await UnitTypeAttributesManager.GetInstance("GameData/UnitTypeAttributes.json");
            UnitTypesManager utManager = await UnitTypesManager.GetInstance("GameData/UnitTypes.json", utaManager);

            MapFactory<Hex> mf = new MapFactory<Hex>();

            Map<Hex> map = mf.CreateMap(MapShape.Circle, 3);

            PlayersManager pm = new PlayersManager();

            pm.CreatePlayers(1);

            
            Unit u = new Unit(utManager.GetUnitType("GermanTank"), map.GetHex(0, 0), pm.GetPlayer(0), HexDirection.Top);

            //Act
            um.AddUnit(u);
            bool result = um.IsInUnits(u);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public async Task ToJsonSuccess()
        {
            //Arrange
            UnitsManager um = new UnitsManager();

            UnitTypeAttributesManager utaManager = await UnitTypeAttributesManager.GetInstance("GameData/UnitTypeAttributes.json");
            UnitTypesManager utManager = await UnitTypesManager.GetInstance("GameData/UnitTypes.json", utaManager);

            MapFactory<Hex> mf = new MapFactory<Hex>();

            Map<Hex> map = mf.CreateMap(MapShape.Circle, 3);

            PlayersManager pm = new PlayersManager();

            pm.CreatePlayers(1);
           
            um.AddUnit(new Unit(utManager.GetUnitType("GermanTank"), map.GetHex(0, 0), pm.GetPlayer(0), HexDirection.Top));
            um.AddUnit(new Unit(utManager.GetUnitType("GermanTank"), map.GetHex(1, 0), pm.GetPlayer(0), HexDirection.Top));
            um.AddUnit(new Unit(utManager.GetUnitType("GermanTank"), map.GetHex(0, 1), pm.GetPlayer(0), HexDirection.Top));

            //Act
            JObject obj = um.ToJson();

            //Assert
            Assert.NotNull(obj);
        }
    }
}
