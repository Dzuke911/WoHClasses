using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using WoH_GameData.Interfaces;
using WoH_Resources.Resources;

namespace WoH_GameData.DataLoader
{
    class GameDataLoader : IGameDataLoader
    {
        public GameDataLoader(string filePath)
        {
            if (!File.Exists(filePath)) { throw new ArgumentException(CodeErrors.FileDoesntExists); }

            dynamic buffer;

            using (StreamReader stream = new StreamReader(filePath))
            {
                buffer = JObject.Parse(stream.ReadToEnd());
            }

            JArray array = buffer[GameStrings.EntitiesPairs];

            string type, path;

            foreach(JObject obj in array)
            {
                type = obj.Value<string>(GameStrings.Type);
                path = obj.Value<string>(GameStrings.Path);
            }
        }
    }
}
