using System;
using System.Collections.Generic;
using System.Text;
using WoH_GameData.GameEntities;

namespace WoH_GameData.Interfaces
{
    public interface IGameDataStorage
    {
        GameObject GetEntity(Type type, string id);
    }
}
