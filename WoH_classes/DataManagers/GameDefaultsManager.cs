using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using WoH_classes.BasicClasses;
using WoH_classes.Enums;
using WoH_classes.Interfaces;
using WoH_classes.Resources;

namespace WoH_classes.DataManagers
{
    public class GameDefaultsManager : IGameDefaultsManager
    {
        private static Dictionary<int, int> _defaultMapSizes;

        public GameDefaultsManager(string filePath)
        {
            if (!File.Exists(filePath))
                throw new ArgumentException(CodeErrors.FileDoesntExists);

            dynamic buffer;

            using (StreamReader stream = new StreamReader(filePath))
            {
                buffer = JObject.Parse(stream.ReadToEnd());
            }

            JArray array = buffer[GameStrings.DefaultMapSizes];

            int playersCount;
            int mapSize;
            Dictionary<int, int> mapSizes = new Dictionary<int, int>();

            foreach (JObject obj in array)
            {
                playersCount = obj[GameStrings.PlayersCount].ToObject<int>();
                mapSize = obj[GameStrings.MapSize].ToObject<int>();

                mapSizes.Add(playersCount, mapSize);
            }

            _defaultMapSizes = mapSizes;
        }

        public MapShape GetDefaultMapShape(int playersCount)
        {
            return MapShape.Circle;
        }

        public int GetDefaultMapSize(int playersCount)
        {
            if (!_defaultMapSizes.ContainsKey(playersCount))
            {
                throw new InvalidOperationException(CodeErrors.NoSuitableMapSize);
            }

            return _defaultMapSizes.GetValueOrDefault(playersCount);
        }
    }
}
