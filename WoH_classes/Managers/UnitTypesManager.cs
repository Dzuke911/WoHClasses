using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using WoH_classes.BasicClasses;
using WoH_classes.Resources;

namespace WoH_classes.Managers
{
    public class UnitTypesManager
    {
        private readonly List<UnitType> _unitTypes;

        private UnitTypesManager(List<UnitType> unitTypes )
        {
            _unitTypes = unitTypes;
        }

        public static async Task<UnitTypesManager> GetInstance(string filePath, UnitTypeAttributesManager unitTypeAttributesManager)
        {
            if (!File.Exists(filePath))
                throw new ArgumentException(CodeErrors.FileDoesntExists);

            dynamic buffer;

            using (StreamReader stream = new StreamReader(filePath))
            {
                buffer = JObject.Parse(await stream.ReadToEndAsync());
            }

            JArray array = buffer[GameStrings.UnitTypes];

            string unitName;
            string[] attributes;
            List<UnitType> list = new List<UnitType>();
            int i = 0;
            int[] attributesInt;

            foreach(JObject obj in array)
            {
                unitName = obj[GameStrings.UnitName].ToObject<string>();
                attributes = obj[GameStrings.UnitTypeAttributes].ToObject<string[]>();

                attributesInt = new int[attributes.Length];

                for (int j = 0; j < attributes.Length; j++)
                {
                    attributesInt[j] = unitTypeAttributesManager.GetID(attributes[j]);
                }

                list.Add( new UnitType(i, unitName, attributesInt));
                i ++;
            }

            return new UnitTypesManager(list);
        }
    }
}
