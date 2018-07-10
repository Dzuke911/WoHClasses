using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace WoH_classes.Interfaces
{
    public interface IGamesManager 
    {
        IGame CreateNewGame(IGameStartModel gameStartModel);
        JObject GetMap(int gameID, string playerID);
        JObject GetUnits(int gameID, string playerID);
    }
}
