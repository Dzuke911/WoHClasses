using System;
using System.Collections.Generic;
using System.Text;

namespace WoH_classes.Interfaces
{
    public abstract class Modificator
    {
        public readonly int Id;
        public readonly string Name;

        public Modificator( int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
