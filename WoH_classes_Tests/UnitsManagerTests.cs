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
using WoH_Data;
using Xunit;

namespace WoH_classes_Tests
{
    public class UnitsManagerTests : BaseTestClass
    {
        const string playerId = "asd";
        GameUnitsManager um;
        MapFactory<Hex> mf;
        Map<Hex> map;
        GamePlayersManager pm;
        Player p;

        public UnitsManagerTests()
        {
            um = new GameUnitsManager();
            mf = new MapFactory<Hex>();
            map = mf.CreateMap(MapShape.Circle, 3);
            pm = new GamePlayersManager(new GameTeamsFactory());
            p = new Player(playerId);
            pm.AddTeam(p);
        }

        [Fact]
        public void AddUnitSuccess()
        {
            //Arrange            

            Unit u = new Unit(_unitTypesManager.GetUnitType("GermanTank"), map.GetHex(0, 0), p, HexDirection.Top);

            //Act
            um.AddUnit(u);
            bool result = um.IsInUnits(u);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void ToJsonSuccess()
        {
            //Arrange

            um.AddUnit(new Unit(_unitTypesManager.GetUnitType("GermanTank"), map.GetHex(0, 0), p, HexDirection.Top));
            um.AddUnit(new Unit(_unitTypesManager.GetUnitType("GermanTank"), map.GetHex(1, 0), p, HexDirection.Top));
            um.AddUnit(new Unit(_unitTypesManager.GetUnitType("GermanTank"), map.GetHex(0, 1), p, HexDirection.Top));

            //Act
            JObject obj = um.ToJson();

            //Assert
            Assert.NotNull(obj);
        }
    }
}
