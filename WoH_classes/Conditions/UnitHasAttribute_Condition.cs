using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WoH_classes.BasicClasses;
using WoH_classes.Enums;
using WoH_classes.Interfaces;

namespace WoH_classes.Conditions
{
    class UnitHasAttribute_Condition : ICondition
    {
        public ConditionType Type { get; }

        private readonly Unit _unit;
        private readonly int _attributeId;

        public UnitHasAttribute_Condition( Unit unit, int attributeId)
        {
            _unit = unit;
            _attributeId = attributeId;
        }

        public bool Check()
        {
            return _unit.Type.AttributesID.Contains(_attributeId);
        }
    }
}
