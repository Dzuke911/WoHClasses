using System;
using System.Collections.Generic;
using System.Text;
using WoH_classes.BasicClasses;
using WoH_classes.Interfaces;
using WoH_classes.Resources;

namespace WoH_classes.GameFactories
{
    public class GameTeamsFactory : IGameTeamsFactory
    {
        public Team GetNewTeam(int id, params Player[] players)
        {
            if (players.Length == 0)
            {
                throw new InvalidOperationException(CodeErrors.CantCreateEmptyTeam);
            }

            Team team = new Team(id);

            foreach(Player p in players)
            {
                team.AddPlayer(p);
            }

            return team;
        }
    }
}
