using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace WoH_classes.BasicClasses
{
    class Team
    {
        public int Id { get; }

        private List<Player> _players;

        public Team(int id)
        {
            _players = new List<Player>();
            Id = id;
        }

        public bool AddPlayer(Player player)
        {
            if (player.Team == null)
            {
                _players.Add(player);
                player.Team = this;
                return true;
            }

            return false;
        }

        public bool RemovePlayer(Player player)
        {
            if (IsInTeam(player))
            {
                _players.Remove(player);
                player.Team = null;
                return true;
            }

            return false;
        }

        public bool IsInTeam(Player player)
        {
            return _players.Contains(player);
        }
    }
}
