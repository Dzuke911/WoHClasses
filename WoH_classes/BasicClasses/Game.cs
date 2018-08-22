﻿using System;
using System.Collections.Generic;
using System.Text;
using WoH_classes.Interfaces;
using WoH_classes.Managers;
using WoH_classes.Maps;

namespace WoH_classes.BasicClasses
{
    public class Game : IGame
    {
        private int _id;
        private Map<Hex> _concreteMap;

        private readonly IGameUnitsManager _gameUnitsManager;
        private readonly IGamePlayersManager _gamePlayersManager;

        private readonly IUnitTypesManager _unitTypesManager;
        private readonly IUnitTypeAttributesManager _unitTypeAttributesManager;

        public Game(int id,
            IGameUnitsManager unitsManager,
            IUnitTypesManager unitTypesManager,
            IUnitTypeAttributesManager unitTypeAttributesManager,
            IGamePlayersManager gamePlayersManager,
            IGameStartModel gameStartModel)
        {
            _id = id;
            _gameUnitsManager = unitsManager;
            _unitTypesManager = unitTypesManager;
            _unitTypeAttributesManager = unitTypeAttributesManager;
            _gamePlayersManager = gamePlayersManager;

            AddTeams(gameStartModel);
        }

        public int Id { get => _id; }

        private void AddTeams(IGameStartModel gameStartModel)
        {
            List<Player> players;

            foreach(Team tm in gameStartModel.GetTeams())
            {
                players = new List<Player>();

                foreach (Player p in tm.GetPlayers())
                {
                    players.Add(p);
                }

                _gamePlayersManager.AddTeam(players.ToArray());
            }
        }
    }
}
