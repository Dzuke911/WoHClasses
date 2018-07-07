using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WoH_classes.BasicClasses;
using WoH_classes.Interfaces;

namespace WoH_classes.Managers
{
    public class GamePlayersManager : IGamePlayersManager
    {
        private readonly List<Player> _players;
        private readonly List<Team> _teams;

        public GamePlayersManager()
        {
            _players = new List<Player>();
            _teams = new List<Team>();
        }

        public bool CreatePlayers(params Player[] players)
        {
            if (_players.Count > 0)
                return false;

            foreach (Player player in players)
            {
                _players.Add(player);

                bool isInTeams = false;
                foreach(Team tm in _teams)
                {

                }
            }

            return true;
        }

        public Player GetPlayer(int id)
        {
            return _players.SingleOrDefault(p => p.Id == id);
        }

        public Team GetTeam(int id)
        {
            return _teams.SingleOrDefault(t => t.Id == id);
        }
    }
}
