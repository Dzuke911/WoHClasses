using System;
using System.Collections.Generic;
using System.Text;
using WoH_classes.BasicClasses;
using System.Linq;
using Newtonsoft.Json.Linq;
using WoH_classes.Resources;

namespace WoH_classes.Managers
{
    public class UnitsManager
    {
        private List<Unit> _units;

        public UnitsManager()
        {
            _units = new List<Unit>();
        }

        public bool AddUnit(Unit unit)
        {
            if (IsInUnits(unit))
                return false;

            _units.Add(unit);

            return true;
        }

        public bool IsInUnits(Unit unit)
        {
            if (unit == null)
                throw new ArgumentNullException(nameof(unit));

            return _units.Contains(unit);
        }

        public bool RemoveUnit(Unit unit)
        {
            if (!IsInUnits(unit))
                return false;

            _units.Remove(unit);

            return true;
        }

        public JObject ToJson()
        {

            JArray units = new JArray();

            foreach (Unit u in _units)
            {
                units.Add(u.ToJson());
            }

            return new JObject(new JProperty(GameStrings.GameUnits, units));
        }

        public int GetUnitId(Unit unit)
        {
            if (!IsInUnits(unit))
                throw new InvalidOperationException(CodeErrors.UnitIsntInUm);

            return _units.IndexOf(unit);
        }
    }
}
