using System;
using System.Collections.Generic;
using System.Text;

namespace WoHclassLibrary
{
    public class Pathing
    {
        public bool Land { get; set; }
        public bool Air { get; set; }

        private int mainUnits;
        private int supportUnits;

        public int MainUnits
        {
            get
            {
                return mainUnits;
            }
            set
            {
                mainUnits = Math.Min(2, Math.Max(0, MainUnits));
            }
        }

        public int SupportUnits
        {
            get
            {
                return SupportUnits;
            }
            set
            {
                supportUnits = Math.Min(2, Math.Max(0, SupportUnits));
            }
        }

        public Pathing(bool land = true, bool air = true, int mainU = 0, int suppU = 0)
        {
            Land = land;
            Air = air;
            MainUnits = mainU;
            SupportUnits = suppU;
        }
    }
}
