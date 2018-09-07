using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using WoH_classes.BasicClasses;
using WoH_classes.Interfaces;

namespace WoH_classes.GameManagers
{
    public class GamesManager : IGamesManager
    {
        private int _lastGameId = 0; // then should start from last created in database
        private readonly List<IGame> _games;
        private readonly IGamesFactory _gamesFactory;

        public GamesManager(IGamesFactory gamesFactory)
        {
            _gamesFactory = gamesFactory;
            _games = new List<IGame>();
        }

        public IGame CreateNewGame(IGameStartModel gameStartModel)
        {
            IGame game = _gamesFactory.GetNewGame(_lastGameId++, gameStartModel);
            _games.Add(game);
            return game;
        }

        public JObject GetMap(int gameID, string playerID)
        {
            throw new NotImplementedException();
        }

        public JObject GetUnits(int gameID, string playerID)
        {
            throw new NotImplementedException();
        }
    }
}
