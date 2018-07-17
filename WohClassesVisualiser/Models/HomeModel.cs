using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WoH_classes.BasicClasses;

namespace Woh_Visualiser.Models
{
    public class HomeModel
    {
        public IEnumerable<Hex> Hexes { get; set; }
    }
}
