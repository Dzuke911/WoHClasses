using System;
using System.Collections.Generic;
using System.Text;

namespace WoH_GameData.GameEntities
{
    public abstract class GameObject
    {
        public readonly string Id;
        public readonly string Name;

        public GameObject(string id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
