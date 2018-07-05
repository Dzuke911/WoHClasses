using System;
using System.Collections.Generic;
using System.Text;
using WoH_classes.BasicClasses;

namespace WoH_classes.Interfaces
{
    public interface IGamePlayersManager
    {
        bool CreatePlayers(params int[] playersInTeamCount);
        Player GetPlayer(int id);
        Team GetTeam(int id);
    }
}
