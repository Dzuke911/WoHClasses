using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using WoH_classes.Interfaces;

namespace WoH_classes.GameManagers
{
    public class GamesManager : IGamesManager
    {
        GamesManager()
        {

        }

        public int CreateNewGame(params string[] playerID)
        {
            throw new NotImplementedException();
        }

        public JObject GetMap(int gameID, params string[] playerID)
        {
            throw new NotImplementedException();
        }

        public JObject GetUnits(int gameID, params string[] playerID)
        {
            throw new NotImplementedException();
        }
    }
}
