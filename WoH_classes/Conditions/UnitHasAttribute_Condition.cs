using System;
using System.Collections.Generic;
using System.Text;
using WoH_classes.Interfaces;

namespace WoH_classes.Conditions
{
    class UnitHasAttribute_Condition : ICondition
    {
        public int UnitTypeID { get; set; }

        public bool Check()
        {
            throw new NotImplementedException();
        }
    }
}
