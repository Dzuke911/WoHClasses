using System;
using System.Collections.Generic;
using System.Text;

namespace WoH_classes.BasicClasses
{
    public class Player
    {
        public readonly string LoginId;

        public Team Team { get; set; }

        public Player(string loginId)
        {
            LoginId = loginId;
        }

        public bool IsAlly(Player player)
        {
            return Team.IsInTeam(player);
        }
    }
}
