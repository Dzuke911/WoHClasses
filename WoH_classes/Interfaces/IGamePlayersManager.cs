using System;
using System.Collections.Generic;
using System.Text;
using WoH_classes.BasicClasses;

namespace WoH_classes.Interfaces
{
    public interface IGamePlayersManager
    {
        int AddTeam(params Player[] players);
        Player GetPlayer(string loginID);
        Team GetTeam(int id);
    }
}
