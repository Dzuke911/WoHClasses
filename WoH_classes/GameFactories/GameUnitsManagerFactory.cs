using System;
using System.Collections.Generic;
using System.Text;
using WoH_classes.Interfaces;
using WoH_classes.Managers;

namespace WoH_classes.GameFactories
{
    class GameManagersFactory : IGameManagersFactory
    {
        public IGamePlayersManager GetPlayersManager(params string[] playersId)
        {
            return new GamePlayersManager(params string[] playersId);
        }

        public IGameUnitsManager GetUnitsManager()
        {
            return new GameUnitsManager();
        }
    }
}
