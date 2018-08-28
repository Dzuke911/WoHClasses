using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using WoH_GameData.DataStorage;
using WoH_GameData.GameEntities;
using WoH_GameData.GameEntities.UnitEntities;
using WoH_GameData.Interfaces;
using WoH_Resources.Resources;

namespace WoH_GameData.DataLoader
{
    class GameDataLoader : IGameDataLoader
    {
        public GameDataStorage GetStorage(string filePath)
        {
            GameDataStorage result = new GameDataStorage();

            if (!File.Exists(filePath)) { throw new ArgumentException(CodeErrors.FileDoesntExists); }

            dynamic buffer;

            using (StreamReader stream = new StreamReader(filePath))
            {
                buffer = JObject.Parse(stream.ReadToEnd());
            }

            JArray array = buffer[GameStrings.EntitiesPairs];

            string type, path;            

            foreach (JObject obj in array)
            {
                type = obj.Value<string>(GameStrings.Type);
                path = obj.Value<string>(GameStrings.Path);

                AddStorage(type, path, result);
            }

            return result;
        }

        private void AddStorage(string typeName, string path, GameDataStorage storage)
        {
            if (!File.Exists(path)) { throw new ArgumentException(CodeErrors.FileDoesntExists); }

            dynamic buffer;

            using (StreamReader stream = new StreamReader(path))
            {
                buffer = JObject.Parse(stream.ReadToEnd());
            }

            JArray array = buffer[typeName];

            Type t = GetTypeByName(typeName);

            GameEntityStorage smallStorage = storage.AddStorage(t);

            foreach (JObject obj in array)
            {                
                storage.AddEntity(CreateEntity(t, obj, storage), smallStorage);
            }
        }

        private GameObject CreateEntity(Type type, JObject obj, GameDataStorage storage)
        {
            ConstructorInfo cInfo = type.GetConstructor(new Type[] { typeof(string), typeof(string) });

            if (cInfo == null) { throw new InvalidOperationException(); } //add gamestrings exception message

            object entity = cInfo.Invoke(new object[] { obj.Value<string>("Id"), obj.Value<string>("Name") }); //add gamestrings params names

            //Add all fields!!!
            foreach(PropertyInfo pInfo in type.GetProperties())
            {
                AddProperty( entity,pInfo, obj, storage);
            }

            if(entity is GameObject)
            {
                return (GameObject)entity;
            }
            else
                throw new InvalidOperationException(); //add gamestrings exception message
        }

        private void AddProperty( object entity, PropertyInfo pInfo, JObject obj, GameDataStorage storage)
        {
            Type[] genericsArgs = pInfo.PropertyType.GetGenericArguments();

            Type entityType;

            if (genericsArgs.Length == 1)
            {
                entityType = genericsArgs.Single();
                if(typeof(IEnumerable).IsAssignableFrom(pInfo.PropertyType))
                {
                    JArray array = obj.Value<JArray>(pInfo.Name);

                    foreach(JValue jName in array)
                    {
                        ((IList)pInfo.GetValue(entity)).Add(storage.GetEntity(entityType, jName.Value<string>()));
                    }
                }

                return;
            }

            

            entityType = pInfo.PropertyType;

            if (typeof(GameObject).IsAssignableFrom(entityType))
            {
                pInfo.SetValue(entity, storage.GetEntity(entityType, obj.Value<string>(pInfo.Name)));
                return;
            }

            if (entityType == typeof(string))
            {
                pInfo.SetValue(entity,obj.Value<string>(pInfo.Name));
                return;
            }

            if (entityType == typeof(int))
            {
                pInfo.SetValue(entity, obj.Value<int>(pInfo.Name));
                return;
            }

            if (entityType == typeof(float))
            {
                pInfo.SetValue(entity, obj.Value<float>(pInfo.Name));
                return;
            }
        }

        private Type GetTypeByName(string typeName)
        {
            return typeof(GameDataLoader).Assembly.GetType("WoH_GameData.GameEntities.UnitEntities." + typeName);

            //Add algorithm to find types in another namespaces
        }
    }
}
