using System;
using System.Collections.Generic;
using System.Text;
using WoH_GameData.DataStorage;

namespace WoH_GameData.Interfaces
{
    public interface IGameDataLoader
    {
        GameDataStorage GetStorage(string filePath);
    }
}
