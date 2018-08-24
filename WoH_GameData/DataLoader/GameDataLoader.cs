using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using WoH_GameData.DataStorage;
using WoH_GameData.GameEntities;
using WoH_GameData.Interfaces;
using WoH_Resources.Resources;

namespace WoH_GameData.DataLoader
{
    class GameDataLoader : IGameDataLoader
    {
        internal IGameDataStorage GetStorage(string filePath)
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

            Type t = typeof(GameDataLoader).Assembly.GetType("WoH_GameData.GameEntities.UnitEntities."+typeName);

            GameEntityStorage smallStorage = storage.AddStorage(t);

            ConstructorInfo cInfo;

            foreach (JObject jObj in array)
            {
                cInfo = t.GetConstructor(new Type[] { typeof(string),typeof(string)});

                if(cInfo == null) { throw new InvalidOperationException(); }

                var obj = cInfo.Invoke(new object[] { jObj.Value<string>("Id"), jObj.Value<string>("Name") });

                //Add all fields!!!

                storage.AddEntity((GameObject)obj, smallStorage);
            }
        }
    }
}
