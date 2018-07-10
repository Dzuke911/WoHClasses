using System;
using System.Collections.Generic;
using System.Text;

namespace WoH_classes.Interfaces
{
    public interface IGamesFactory
    {
        IGame GetNewGame(int id, IGameStartModel gameStartModel);
    }
}
