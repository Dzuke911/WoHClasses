using System;
using System.Collections.Generic;
using System.Text;
using WoH_classes.Interfaces;

namespace WoH_classes.BasicClasses
{
    public class UnitType : ObjectType
    {
        public readonly IEnumerable<UnitTypeAttribute> Attributes;

        public UnitType(string id, string name, IEnumerable<UnitTypeAttribute> attributes) : base(id, name)
        {
            Attributes = attributes;
        }
    }
}
