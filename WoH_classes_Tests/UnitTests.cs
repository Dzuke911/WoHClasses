using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WoH_classes.Accounts;
using WoH_classes.BasicClasses;
using WoH_classes.DataManagers;
using WoH_classes.Enums;
using WoH_classes.GameFactories;
using WoH_classes.GameManagers;
using WoH_classes.Interfaces;
using WoH_classes.Managers;
using WoH_classes.Maps;
using WoH_Data;
using Xunit;

namespace WoH_classes_Tests
{
    public class UnitTests: BaseTestClass
    {
        [Fact]
        public void ConstructorSuccess()
        {
            //Arrange
            const string playerId = "asd";

            MapFactory<Hex> mf = new MapFactory<Hex>();

            Map<Hex> map = mf.CreateMap(MapShape.Circle, 3);

            GamePlayersManager pm = new GamePlayersManager(new GameTeamsFactory());
            Player p = new Player(playerId);

            pm.AddTeam(p);

            //Act
            Unit u = new Unit( _unitTypesManager.GetUnitType("GermanTank"), map.GetHex(0, 0), p, HexDirection.Top);

            //Assert
            Assert.NotNull(u);
        }

        [Fact]
        public void ToJsonSuccess()
        {
            //Arrange
            const string playerId = "asd";

            MapFactory<Hex> mf = new MapFactory<Hex>();

            Map<Hex> map = mf.CreateMap(MapShape.Circle, 3);

            GamePlayersManager pm = new GamePlayersManager(new GameTeamsFactory());
            Player p = new Player(playerId);

            pm.AddTeam(p);

            Unit u = new Unit(_unitTypesManager.GetUnitType("GermanTank"), map.GetHex(0, 0), p, HexDirection.Top);

            //Act
            JObject obj = u.ToJson();

            //Assert
            Assert.NotNull(obj);
        }
    }
}
