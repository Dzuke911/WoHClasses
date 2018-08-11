using System;
using System.Collections.Generic;
using System.Text;

namespace WoH_classes.Interfaces
{
    public abstract class ObjectType
    {
        public readonly string Id;
        public readonly string Name;

        public ObjectType(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
