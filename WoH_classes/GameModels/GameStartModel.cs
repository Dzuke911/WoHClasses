using System;
using System.Collections.Generic;
using System.Text;
using WoH_classes.BasicClasses;
using WoH_classes.Interfaces;

namespace WoH_classes.GameModels
{
    class GameStartModel : IGameStartModel
    {
        public readonly List<Team> _teams;
        public readonly bool isValid;

        public GameStartModel(params Team[] teams)
        {
            _teams = new List<Team>();
            isValid = true;

            foreach(Team tm in teams)
            {
                if (tm == null)
                {
                    throw new ArgumentNullException(nameof(teams));
                }

                if (tm.Count() == 0)
                {
                    isValid = false;
                }
                else
                {
                    _teams.Add(tm);
                }
            }
        }

        public IEnumerable<Team> GetTeams()
        {
            return _teams;
        }
    }
}
