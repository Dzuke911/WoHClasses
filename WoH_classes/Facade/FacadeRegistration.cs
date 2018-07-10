using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using WoH_classes.BasicClasses;
using WoH_classes.GameFactories;
using WoH_classes.Interfaces;
using WoH_classes.Managers;
using WoH_classes.Maps;

namespace WoH_classes.Facade
{
    public static class FacadeRegistration
    {
        private static UnitTypeAttributesManager _unitTypeAttributesManager;
        private static UnitTypesManager _unitTypesManager;

        public static void ConfigureServices(IServiceCollection services)
        {
            CreateDataManagers();

            services.AddTransient(f => new MapFactory<Hex>());

            services.AddTransient<IGameTeamsFactory, GameTeamsFactory>(s => new GameTeamsFactory());
            services.AddTransient<IGameUnitsManager, GameUnitsManager>(s => new GameUnitsManager());
            services.AddTransient<IUnitTypesManager, UnitTypesManager>(s => _unitTypesManager);
            services.AddTransient<IUnitTypeAttributesManager,UnitTypeAttributesManager>(s => _unitTypeAttributesManager);

            services.AddTransient<IGamePlayersManager, GamePlayersManager>(s => new GamePlayersManager(s.GetService<IGameTeamsFactory>()));
            services.AddTransient<IGame, Game>(s => new Game(s.GetService<IGameUnitsManager>(),s.GetService<IUnitTypesManager>(), s.GetService<IUnitTypeAttributesManager>(), s.GetService<IGamePlayersManager>()));
        }

        private static void CreateDataManagers()
        {
            Task<UnitTypeAttributesManager> utam = UnitTypeAttributesManager.GetInstance("GameData/UnitTypeAttributes.json");
            _unitTypeAttributesManager = utam.Result;

            Task<UnitTypesManager> utm = UnitTypesManager.GetInstance("GameData/UnitTypes.json", _unitTypeAttributesManager);
            _unitTypesManager = utm.Result;
        }
    }
}
