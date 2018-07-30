using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using WoH_classes.Interfaces;
using WoH_classes.Resources;

namespace WoH_classes.Managers
{
    public class UnitTypeAttributesManager : IUnitTypeAttributesManager
    {
        private readonly string[] _attributes;

        public int GetAttributeID(string name)
        {
            for (int i = 0; i < _attributes.Length; i++)
            {
                if (name == _attributes[i])
                    return i;
            }

            throw new InvalidOperationException(CodeErrors.UnitTypeAttributeNotExist);
        }

        public UnitTypeAttributesManager(string filePath)
        {
            if (!File.Exists(filePath)) { throw new ArgumentException(CodeErrors.FileDoesntExists); }

            dynamic buffer;

            using (StreamReader stream = new StreamReader(filePath))
            {
                buffer = JObject.Parse(stream.ReadToEnd());
            }

            JArray array = buffer[GameStrings.UnitTypeAttributes];

            _attributes = array.ToObject<string[]>();
        }
    }
}
