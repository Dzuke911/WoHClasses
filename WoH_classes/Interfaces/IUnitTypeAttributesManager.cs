﻿using System;
using System.Collections.Generic;
using System.Text;
using WoH_classes.BasicClasses;

namespace WoH_classes.Interfaces
{
    public interface IUnitTypeAttributesManager
    {
        UnitTypeAttribute GetAttribute(string name);
    }
}
