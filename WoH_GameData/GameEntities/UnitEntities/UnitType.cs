using System;
using System.Collections.Generic;
using System.Text;

namespace WoH_GameData.GameEntities.UnitEntities
{
    class UnitType : GameObject
    {
        public readonly List<UnitTypeAttribute> Attributes;

        public UnitType(string id, string name) : base(id, name)
        {
            Attributes = new List<UnitTypeAttribute>();
        }
    }
}
