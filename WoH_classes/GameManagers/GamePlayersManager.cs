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

        public bool CreatePlayers(params int[] playersInTeamCount)
        {
            if (_players.Count > 0)
                return false;

            int playerId = 0, teamId = 0;
            Player currPlayer;
            Team currTeam;

            foreach (int num in playersInTeamCount)
            {
                currTeam = new Team(teamId++);
                _teams.Add(currTeam);

                for (int i = 0; i < num; i++)
                {
                    currPlayer = new Player(playerId++);
                    currTeam.AddPlayer(currPlayer);

                    _players.Add(currPlayer);
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
