using System;
using System.Collections.Generic;
using System.Text;
using WoH_classes.BasicClasses;

namespace WoH_classes.Interfaces
{
    public interface IGameTeamsFactory
    {
        Team GetNewTeam(int id, params Player[] players);
    }
}
