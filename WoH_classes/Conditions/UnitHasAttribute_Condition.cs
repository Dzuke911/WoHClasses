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
        private readonly string _attributeId;

        public UnitHasAttribute_Condition( Unit unit, string attributeId)
        {
            _unit = unit;
            _attributeId = attributeId;
        }

        public bool Check()
        {
            if (_unit.Type.Attributes.SingleOrDefault(a => a.Id == _attributeId) == null)
                return false;

            return true;
        }
    }
}
