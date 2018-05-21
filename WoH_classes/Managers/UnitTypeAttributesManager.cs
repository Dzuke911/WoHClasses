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

            dynamic buff;

            using (StreamReader stream = new StreamReader(filePath))
            {
                buff = JObject.Parse(await stream.ReadToEndAsync());
            }

            JArray array = buff[GameStrings.UnitTypeAttributes];

            return new UnitTypeAttributesManager(array.ToObject<string[]>());
        }
    }
}
