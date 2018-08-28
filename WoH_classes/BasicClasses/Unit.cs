using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using WoH_classes.Enums;
using WoH_Resources.Resources;
using WoH_GameData.GameEntities.UnitEntities;

namespace WoH_classes.BasicClasses
{
    public class Unit
    {
        public readonly UnitType Type;
        public Player Owner { get; set; }

        public Hex Position { get; set; }

        public HexDirection Direction { get; set; }

        public Unit(WoH_GameData.GameEntities.UnitEntities.UnitType type, Hex pos, Player owner, HexDirection direction)
        {
            Type = type;
            Owner = owner;
            Direction = direction;

            if (!pos.IsFreeForUnit(this))
                throw new InvalidOperationException(CodeErrors.CantAddUnitToHex);

            Position = pos;
            Position.AddUnit(this);
        }

        public JObject ToJson()
        {
            return new JObject(new JProperty(UnitJsonStrings.UnitTypeName, Type.Name),
                new JProperty(UnitJsonStrings.UnitTypeId, Type.Id),
                new JProperty(UnitJsonStrings.UnitOwner, Owner.LoginId),
                new JProperty(UnitJsonStrings.UnitPosition, Position.Id),
                new JProperty(UnitJsonStrings.UnitDirection, Direction.ToString()));
        }
    }
}
