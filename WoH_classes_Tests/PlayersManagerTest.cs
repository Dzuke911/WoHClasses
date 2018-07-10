using System;
using System.Collections.Generic;
using System.Text;
using WoH_classes.BasicClasses;
using WoH_classes.GameFactories;
using WoH_classes.Managers;
using Xunit;

namespace WoH_classes_Tests
{
    public class PlayersManagerTest
    {
        [Fact]
        public void ConstructorSuccess()
        {
            GamePlayersManager pm1 = new GamePlayersManager(new GameTeamsFactory());

            Assert.NotNull(pm1);
        }

        [Fact]
        public void AddTeamSuccess()
        {
            int teamId = -1;
            const string playerId = "asdfasd";
            Player p = new Player(playerId);
            GamePlayersManager pm = new GamePlayersManager(new GameTeamsFactory());

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

            GamePlayersManager pm = new GamePlayersManager(new GameTeamsFactory());

            Assert.Throws<ArgumentNullException>(() => { pm.AddTeam(p, null); });
        }
    }
}
