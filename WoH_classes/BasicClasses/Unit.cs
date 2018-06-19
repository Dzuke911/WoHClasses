using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using WoH_classes.Resources;

namespace WoH_classes.BasicClasses
{
    public class Unit
    {
        public readonly UnitType Type;
        public Player Owner { get; set; }

        public Hex position { get; set; }

        public Unit( UnitType type, Hex pos, Player owner)
        {
            position = pos;
            Type = type;
            Owner = owner;
        }

        public JObject ToJson()
        {
            return new JObject(new JProperty(UnitJsonStrings.UnitTypeName, Type.Name),
                new JProperty(UnitJsonStrings.UnitTypeId, Type.Id),
                new JProperty(UnitJsonStrings.UnitOwner, Owner.Id),
                new JProperty(UnitJsonStrings.UnitPosition, position.Id));
        }
    }
}
