using System;
using System.Collections.Generic;
using System.Text;

namespace WoH_classes.Interfaces
{
    public abstract class ObjectType
    {
        public readonly int Id;
        public readonly string Name;

        public ObjectType(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
