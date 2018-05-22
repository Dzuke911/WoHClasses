using System;
using System.Collections.Generic;
using System.Text;
using WoH_classes.Interfaces;

namespace WoH_classes.BasicClasses
{
    class SearchArea_Units
    {
        private readonly int _radius;
        private readonly int _resultNumber;
        private readonly List<ICondition> _conditions;

        public SearchArea_Units(int radius, int resultNumber, List<ICondition> conditions)
        {
            _radius = radius;
            _resultNumber = resultNumber;
            _conditions = conditions;
        }
    }
}
