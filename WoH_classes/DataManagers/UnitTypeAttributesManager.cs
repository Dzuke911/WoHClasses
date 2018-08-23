using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoH_classes.BasicClasses;
using WoH_classes.Interfaces;
using WoH_Resources.Resources;

namespace WoH_classes.Managers
{
    public class UnitTypeAttributesManager : IUnitTypeAttributesManager
    {
        private readonly List<UnitTypeAttribute> _attributes;

        public UnitTypeAttribute GetAttribute(string id)
        {
            try
            {
                return _attributes.Single(a => a.Id == id);
            }
            catch
            {
                throw new InvalidOperationException(CodeErrors.UnitTypeAttributeNotExist);
            }                        
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

            _attributes = new List<UnitTypeAttribute>();

            foreach(JObject obj in array)
            {
                _attributes.Add(new UnitTypeAttribute(obj[GameStrings.Id].ToObject<string>(), obj[GameStrings.Name].ToObject<string>()));
            }
        }
    }
}
