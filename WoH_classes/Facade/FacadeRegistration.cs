using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using WoH_classes.BasicClasses;
using WoH_classes.DataManagers;
using WoH_classes.GameFactories;
using WoH_classes.GameManagers;
using WoH_classes.Interfaces;
using WoH_classes.Managers;
using WoH_classes.Maps;

namespace WoH_classes.Facade
{
    public static class FacadeRegistration
    {
        private static IUnitTypeAttributesManager _unitTypeAttributesManager;
        private static IUnitTypesManager _unitTypesManager;
        private static IGameDefaultsManager _gameDefaultsManager;


        public static void ConfigureServices(IServiceCollection services)
        {
            CreateDataManagers();

            services.AddTransient(f => new MapFactory<Hex>());

            services.AddTransient<IGameTeamsFactory, GameTeamsFactory>(s => new GameTeamsFactory());
            services.AddTransient<IGameUnitsManager, GameUnitsManager>(s => new GameUnitsManager());
            services.AddTransient(s => _unitTypesManager);
            services.AddTransient(s => _unitTypeAttributesManager);


            services.AddTransient<IGamePlayersManager, GamePlayersManager>(s => new GamePlayersManager(s.GetService<IGameTeamsFactory>()));
            services.AddTransient<IGameManagersFactory, GameManagersFactory>(s => new GameManagersFactory(s.GetService<IGameTeamsFactory>()));

            services.AddTransient<IGamesFactory, GamesFactory>(s => new GamesFactory(s.GetService<IGameManagersFactory>(), _unitTypesManager, _unitTypeAttributesManager));
            services.AddTransient<IGamesManager, GamesManager>(s => new GamesManager(s.GetService<IGamesFactory>()));
        }

        private static void CreateDataManagers()
        {
            Task<UnitTypeAttributesManager> utam = UnitTypeAttributesManager.GetInstance("GameData/UnitTypeAttributes.json");
            _unitTypeAttributesManager = utam.Result;

            Task<UnitTypesManager> utm = UnitTypesManager.GetInstance("GameData/UnitTypes.json", _unitTypeAttributesManager);
            _unitTypesManager = utm.Result;

            Task<GameDefaultsManager> gdm = GameDefaultsManager.GetInstance("GameData/GameDefaults.json");
            _gameDefaultsManager = gdm.Result;
        }
    }
}
