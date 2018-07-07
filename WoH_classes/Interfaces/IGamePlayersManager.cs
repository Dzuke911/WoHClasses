using System;
using System.Collections.Generic;
using System.Text;
using WoH_classes.BasicClasses;

namespace WoH_classes.Interfaces
{
    public interface IGamePlayersManager
    {
        bool CreatePlayers(params Team[] teams);
        Player GetPlayer(int id);
        Team GetTeam(int id);
    }
}
