using System;
using System.Collections.Generic;
using System.Text;
using WoH_classes.Enums;

namespace WoH_classes.Interfaces
{
    public interface IGameDefaultsManager
    {
        int GetDefaultMapSize(int playersCount);
        MapShape GetDefaultMapShape(int playersCount);
    }
}
