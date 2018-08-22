using System;
using System.Collections.Generic;
using System.Text;
using WoH_classes.BasicClasses;
using WoH_classes.Interfaces;

namespace WoH_classes.GameFactories
{
    public class GamesFactory : IGamesFactory
    {
        private readonly IGameManagersFactory _gameManagersFactory;
        private readonly IUnitTypesManager _unitTypesManager;
        private readonly IUnitTypeAttributesManager _unitTypeAttributesManager;

        public GamesFactory(IGameManagersFactory gameManagersFactory,
                    IUnitTypesManager unitTypesManager,
                    IUnitTypeAttributesManager unitTypeAttributesManager)
        {
            _gameManagersFactory = gameManagersFactory;
            _unitTypesManager = unitTypesManager;
            _unitTypeAttributesManager = unitTypeAttributesManager;
        }

        public IGame GetNewGame(int id , IGameStartModel gameStartModel)
        {
            Game game = new Game(id, _gameManagersFactory.GetUnitsManager(),_unitTypesManager,_unitTypeAttributesManager, _gameManagersFactory.GetPlayersManager(), gameStartModel);

            return game;
        }
    }
}
