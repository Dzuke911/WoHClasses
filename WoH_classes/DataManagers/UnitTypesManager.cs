using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WoH_classes.BasicClasses;
using WoH_classes.Interfaces;
using WoH_classes.Resources;

namespace WoH_classes.Managers
{
    public class UnitTypesManager : IUnitTypesManager
    {
        private readonly List<UnitType> _unitTypes;

        public UnitTypesManager(string filePath, IUnitTypeAttributesManager unitTypeAttributesManager)
        {
            if (!File.Exists(filePath))
                throw new ArgumentException(CodeErrors.FileDoesntExists);

            dynamic buffer;

            using (StreamReader stream = new StreamReader(filePath))
            {
                buffer = JObject.Parse(stream.ReadToEnd());
            }

            JArray array = buffer[GameStrings.UnitTypes];

            string unitName;
            string[] attributes;
            List<UnitType> list = new List<UnitType>();
            int i = 0;
            int[] attributesInt;

            foreach (JObject obj in array)
            {
                unitName = obj[GameStrings.UnitName].ToObject<string>();
                attributes = obj[GameStrings.UnitTypeAttributes].ToObject<string[]>();

                attributesInt = new int[attributes.Length];

                for (int j = 0; j < attributes.Length; j++)
                {
                    attributesInt[j] = unitTypeAttributesManager.GetAttributeID(attributes[j]);
                }

                list.Add(new UnitType(i, unitName, attributesInt));
                i++;
            }

            _unitTypes = list;
        }

        public UnitType GetUnitType(string typeName)
        {
            return _unitTypes.SingleOrDefault(ut => ut.Name == typeName);
        }
    }
}
