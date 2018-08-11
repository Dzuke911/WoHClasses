using System;
using System.Collections.Generic;
using System.Text;
using WoH_classes.Interfaces;

namespace WoH_classes.BasicClasses
{
    public class UnitTypeAttribute : ObjectType
    {
        public UnitTypeAttribute(string id, string name) : base(id, name)
        {
        }
    }
}
