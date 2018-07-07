using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace WoH_classes.Interfaces
{
    public interface IGamesManager
    {
        int CreateNewGame(params string[] playerID);
        JObject GetMap(int gameID,params string[] playerID);
        JObject GetUnits(int gameID,params string[] playerID);
    }
}
