using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using WoH_classes.BasicClasses;

namespace WoH_classes.Interfaces
{
    public interface IGameUnitsManager
    {
        bool AddUnit(Unit unit);
        bool IsInUnits(Unit unit);
        bool RemoveUnit(Unit unit);        
        int GetUnitId(Unit unit);
        JObject ToJson();
    }
}
