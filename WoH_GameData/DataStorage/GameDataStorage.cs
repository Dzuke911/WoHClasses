using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WoH_GameData.GameEntities;
using WoH_GameData.Interfaces;

namespace WoH_GameData.DataStorage
{
    public class GameDataStorage : IGameDataStorage
    {
        private readonly List<GameEntityStorage> _entities;

        internal GameDataStorage()
        {
            _entities = new List<GameEntityStorage>();
        }

        internal GameEntityStorage AddStorage(Type type)
        {
            GameEntityStorage storage = new GameEntityStorage(type);

            if(_entities.FirstOrDefault(s => s.EntityType == storage.EntityType) != null) { throw new InvalidOperationException(); }

            _entities.Add(storage);

            return storage;
        }

        internal void AddEntity(GameObject obj)
        {
            Type t = obj.GetType();

            GameEntityStorage storage = _entities.FirstOrDefault(s => s.EntityType == obj.GetType());

            if(storage == null) { throw new InvalidOperationException(); }

            storage.AddEntity(obj);
        }

        internal void AddEntity(GameObject obj, GameEntityStorage storage)
        {
            storage.AddEntity(obj);
        }

        public GameObject GetEntity(Type type, string id)
        {
            GameEntityStorage smallStorage = _entities.SingleOrDefault(e => e.EntityType == type);

            return smallStorage.GetEntity(id);
        }
    }
}
