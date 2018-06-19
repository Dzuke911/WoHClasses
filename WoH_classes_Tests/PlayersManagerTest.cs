using System;
using System.Collections.Generic;
using System.Text;
using WoH_classes.Managers;
using Xunit;

namespace WoH_classes_Tests
{
    public class PlayersManagerTest
    {
        [Fact]
        public void ConstructorSuccess()
        {
            PlayersManager pm1 = new PlayersManager();

            Assert.NotNull(pm1);
        }

        [Fact]
        public void CreatePlayersSuccess()
        {
            PlayersManager pm = new PlayersManager();

            bool res = pm.CreatePlayers(3, 3);

            Assert.True(res);
            Assert.NotNull(pm.GetPlayer(0));
            Assert.NotNull(pm.GetPlayer(1));
            Assert.NotNull(pm.GetPlayer(2));
            Assert.NotNull(pm.GetPlayer(3));
            Assert.NotNull(pm.GetPlayer(4));
            Assert.NotNull(pm.GetPlayer(5));

            Assert.Null(pm.GetPlayer(6));

            Assert.NotNull(pm.GetTeam(0));
            Assert.NotNull(pm.GetTeam(1));
        }

        [Fact]
        public void CreatePlayersFail_AlreadyCreated()
        {
            PlayersManager pm = new PlayersManager();

            bool res = pm.CreatePlayers(1);
            res = pm.CreatePlayers(1);

            Assert.False(res);
        }
    }
}
