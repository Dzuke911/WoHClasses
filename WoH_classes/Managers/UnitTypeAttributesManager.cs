using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using WoH_classes.Resources;

namespace WoH_classes.Managers
{
    public class UnitTypeAttributesManager
    {
        private readonly string[] _attributes;
        private static string _filePath;
        private static UnitTypeAttributesManager _instance;

        public int GetID(string name)
        {
            for( int i = 0; i < _attributes.Length; i++)
            {
                if (name == _attributes[i])
                    return i;
            }

            throw new InvalidOperationException(CodeErrors.UnitTypeAttributeNotExist);
        }

        private UnitTypeAttributesManager(string[] attributes)
        {
            _attributes = attributes;
        }

        public static async Task<UnitTypeAttributesManager> GetInstance(string filePath)
        {
            if (!File.Exists(filePath))
                throw new ArgumentException(CodeErrors.FileDoesntExists);

            if( _instance == null || _filePath != filePath)
            {
                _filePath = filePath;

                dynamic buffer;

                using (StreamReader stream = new StreamReader(filePath))
                {
                    buffer = JObject.Parse(await stream.ReadToEndAsync());
                }

                JArray array = buffer[GameStrings.UnitTypeAttributes];

                _instance = new UnitTypeAttributesManager(array.ToObject<string[]>());
            }

            return _instance;
        }
    }
}
