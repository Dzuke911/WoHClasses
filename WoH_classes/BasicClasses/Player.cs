using System;
using System.Collections.Generic;
using System.Text;

namespace WoH_classes.BasicClasses
{
    public class Player
    {
        public int Id { get; }

        public Team Team { get; set; }

        public Player(int id)
        {
            Id = id;
        }

        public bool IsAlly(Player player)
        {
            return Team.IsInTeam(player);
        }
    }
}
