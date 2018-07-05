using System;
using System.Collections.Generic;
using System.Text;
using WoH_classes.Interfaces;
using WoH_classes.Managers;

namespace WoH_classes.BasicClasses
{
    public class Game : IGame
    {
        private readonly IGameUnitsManager _gameUnitsManager;
        private readonly IGamePlayersManager _gamePlayersManager;

        private readonly IUnitTypesManager _unitTypesManager;
        private readonly IUnitTypeAttributesManager _unitTypeAttributesManager;


        public Game(IGameUnitsManager unitsManager,
            IUnitTypesManager unitTypesManager,
            IUnitTypeAttributesManager unitTypeAttributesManager,
            IGamePlayersManager gamePlayersManager)
        {
            _gameUnitsManager = unitsManager;
            _unitTypesManager = unitTypesManager;
            _unitTypeAttributesManager = unitTypeAttributesManager;
            _gamePlayersManager = gamePlayersManager;
        }
    }
}
