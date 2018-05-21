using System;
using System.Collections.Generic;
using System.Text;
using WoH_classes.Interfaces;

namespace WoH_classes.BasicClasses
{
    public class UnitType : ObjectType
    {
        public int[] AttributesID;

        public UnitType(int id, string name, int[] attributesID) : base(id, name)
        {
            AttributesID = attributesID;
        }
    }
}
