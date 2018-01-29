using System;
using System.Collections.Generic;
using System.Text;

namespace WoHclassLibrary
{
    class Cost
    {
        public decimal Value { get; }
        public Parameter Param { get; }

        public Cost( decimal value, Parameter param)
        {
            Value = value;
            Param = param;
        }
    }
}
