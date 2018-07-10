using System;
using System.Collections.Generic;
using System.Text;
using WoH_classes.Interfaces;
using WoH_classes.Managers;

namespace WoH_classes.GameFactories
{
    class GameManagersFactory : IGameManagersFactory
    {
        private readonly IGameTeamsFactory _teamFactory;

        public GameManagersFactory(IGameTeamsFactory teamFactory)
        {
            _teamFactory = teamFactory;
        }

        public IGamePlayersManager GetPlayersManager()
        {
            return new GamePlayersManager(_teamFactory);
        }

        public IGameUnitsManager GetUnitsManager()
        {
            return new GameUnitsManager();
        }
    }
}
