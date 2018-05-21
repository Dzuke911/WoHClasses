using System;
using System.Collections.Generic;
using System.Text;
using WoH_classes.Enums;

namespace WoH_classes.Interfaces
{
    public interface ICondition
    {
        ConditionType Type { get; }

        bool Check();
    }
}
