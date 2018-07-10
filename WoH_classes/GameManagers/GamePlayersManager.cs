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
        private int _lastTeamId = 0;
        private readonly IGameTeamsFactory _teamsFactory;
        private readonly List<Player> _players;
        private readonly List<Team> _teams;

        public GamePlayersManager(IGameTeamsFactory teamsFactory)
        {
            _teamsFactory = teamsFactory;
            _players = new List<Player>();
            _teams = new List<Team>();
        }

        public int AddTeam(params Player[] players)
        {
            foreach (Player p in players)
            {
                if(p == null)
                {
                    throw new ArgumentNullException(nameof(players));
                }

                if (!_players.Contains(p))
                {
                    _players.Add(p);
                }
            }

            Team team = _teamsFactory.GetNewTeam(_lastTeamId++, players);

            _teams.Add(team);

            return team.Id;
        }

        public Player GetPlayer(string loginId)
        {
            return _players.SingleOrDefault(p => p.LoginId == loginId);
        }

        public Team GetTeam(int id)
        {
            return _teams.SingleOrDefault(t => t.Id == id);
        }
    }
}
