using System;
using System.Collections.Generic;
using System.Text;
using WoH_classes.BasicClasses;
using WoH_classes.GameFactories;
using WoH_classes.Managers;
using Xunit;

namespace WoH_classes_Tests
{
    public class GamePlayersManagerTest
    {
        GamePlayersManager pm;

        public GamePlayersManagerTest()
        {
            pm = new GamePlayersManager(new GameTeamsFactory());
        }

        [Fact]
        public void ConstructorSuccess()
        {
            Assert.NotNull(pm);
        }

        [Fact]
        public void AddTeamSuccess()
        {
            int teamId = -1;
            const string playerId = "asdfasd";
            Player p = new Player(playerId);

            teamId = pm.AddTeam(p);

            Assert.True(teamId != -1);
            Assert.NotNull(pm.GetPlayer(playerId));
            Assert.NotNull(pm.GetTeam(teamId));
        }

        [Fact]
        public void AddTeamFail_NullPlayer()
        {
            const string playerId = "asdfasd";
            Player p = new Player(playerId);

            Assert.Throws<ArgumentNullException>(() => { pm.AddTeam(p, null); });
        }
    }
}
