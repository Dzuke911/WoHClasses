using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WoH_GameData.GameEntities;

namespace WoH_GameData.DataStorage
{
    class GameEntityStorage
    {
        public readonly Type EntityType;

        private readonly List<GameObject> _list;

        internal GameEntityStorage(Type type)
        {
            if(!(typeof(GameObject)).IsAssignableFrom(type)) { throw new InvalidOperationException(); }

            EntityType = type;
            _list = new List<GameObject>();
        }

        internal void AddEntity(GameObject obj)
        {
            if (obj.GetType() != EntityType) { throw new InvalidOperationException(); }

            if( _list.FirstOrDefault(e => e.Id == obj.Id) != null) { throw new InvalidOperationException(); }

            _list.Add(obj);
        }

        internal GameObject GetEntity(string id)
        {
            return _list.SingleOrDefault(e => e.Id == id);
        }
    }
}
