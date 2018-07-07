using System;
using System.Collections.Generic;
using System.Text;
using WoH_classes.BasicClasses;

namespace WoH_classes.Interfaces
{
    interface IGameManagersFactory
    {
        IGameUnitsManager GetUnitsManager();
        IGamePlayersManager GetPlayersManager(params Team[] teams);
    }
}
