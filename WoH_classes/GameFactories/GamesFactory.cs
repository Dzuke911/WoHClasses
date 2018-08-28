using System;
using System.Collections.Generic;
using System.Text;
using WoH_classes.BasicClasses;
using WoH_classes.Interfaces;

namespace WoH_classes.GameFactories
{
    public class GamesFactory : IGamesFactory
    {
        private readonly IGameManagersFactory _gameManagersFactory;

        public GamesFactory(IGameManagersFactory gameManagersFactory)
        {
            _gameManagersFactory = gameManagersFactory;
        }

        public IGame GetNewGame(int id , IGameStartModel gameStartModel)
        {
            Game game = new Game(id, _gameManagersFactory.GetUnitsManager(), _gameManagersFactory.GetPlayersManager(), gameStartModel);

            return game;
        }
    }
}
