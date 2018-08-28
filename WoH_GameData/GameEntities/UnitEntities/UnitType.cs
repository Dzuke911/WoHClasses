using System;
using System.Collections.Generic;
using System.Text;

namespace WoH_GameData.GameEntities.UnitEntities
{
    public class UnitType : GameObject
    {
        public IEnumerable<UnitTypeAttribute> Attributes { get; }

        public float MaxLife { get; set; }

        public Race UnitRace { get; set; }

        public UnitType(string id, string name) : base(id, name)
        {
            Attributes = new List<UnitTypeAttribute>();
        }
    }
}
