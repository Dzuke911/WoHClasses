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

            string Id;
            string unitName;
            string[] attributes;
            List<UnitType> list = new List<UnitType>();
            List<UnitTypeAttribute> attributesList;

            foreach (JObject obj in array)
            {
                Id = obj[GameStrings.Id].ToObject<string>();
                unitName = obj[GameStrings.Name].ToObject<string>();
                attributes = obj[GameStrings.UnitTypeAttributes].ToObject<string[]>();

                attributesList = new List<UnitTypeAttribute>();

                foreach(string attrId in attributes)
                {
                    attributesList.Add(unitTypeAttributesManager.GetAttribute(attrId));
                }

                list.Add(new UnitType(Id, unitName, attributesList));
            }

            _unitTypes = list;
        }

        public UnitType GetUnitType(string Id)
        {
            return _unitTypes.SingleOrDefault(ut => ut.Id == Id);
        }
    }
}
